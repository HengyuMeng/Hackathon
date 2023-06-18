using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public Camera cam;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = raycastHit.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;

                if (raycastHit.collider.gameObject.GetComponent<VoiceOverTrigger>() != null)
                {
                    Debug.Log("Trigger Dialogue");
                    raycastHit.collider.gameObject.GetComponent<VoiceOverTrigger>().TriggerDialogue();
                }
                else
                {
                    Debug.Log("Not detected terigger dialog script.");
                }
            }
            else
            {
                if (selection)
                {
                    ObjectInteraction objectInteraction = raycastHit.collider.GetComponent<ObjectInteraction>();

                    if (objectInteraction != null)
                    {
                        objectInteraction.objectInfoUI.DisplayInfo(objectInteraction.objectDescription, objectInteraction.objectSprite);
                        if (raycastHit.collider.gameObject.GetComponent<FillForm>() != null)
                        {
                            raycastHit.collider.gameObject.GetComponent<FillForm>().fillContent();
                        }
                    }
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
        }
    }

}
