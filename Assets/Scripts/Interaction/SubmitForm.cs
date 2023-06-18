using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SubmitForm : MonoBehaviour
{
    public TMP_InputField input_name;
    public TMP_InputField input_age;
    public TMP_InputField input_address;

    public GameObject select_name;
    public GameObject select_age;
    public GameObject select_address;

    // Start is called before the first frame update
    public void checkContent()
    {
        if ((input_name.text == select_name.GetComponent<ObjectInteraction>().formContent) &&
            (input_age.text == select_age.GetComponent<ObjectInteraction>().formContent) &&
            (input_address.text == select_address.GetComponent<ObjectInteraction>().formContent))
            {
                SceneManager.LoadScene("PartIII");
            }
        else 
        {
            this.GetComponent<VoiceOverTrigger>().TriggerDialogue();
        }
    }
}
