using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public ObjectInfoUI objectInfoUI;
    public string objectDescription;
    public Sprite objectSprite;
    public string formContent = "";

    private void OnMouseEnter()
    {
        // Highlight the object or display UI elements.
    }

    private void OnMouseExit()
    {
        // Remove highlighting or hide UI elements.
    }

    private void OnMouseDown()
    {
        // Show the info panel with the object's information
        objectInfoUI.DisplayInfo(objectDescription, objectSprite);
    }
}

