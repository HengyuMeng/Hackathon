using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class FillForm : MonoBehaviour
{
    //public TMP_Text tmp_tobechanged;
    public TMP_InputField inputField;

    public void fillContent()
    {
        string content = inputField.text;
        Debug.Log("Current input field is" + content);
        if (this.GetComponent<ObjectInteraction>().formContent != "") {
            inputField.text = this.GetComponent<ObjectInteraction>().formContent;
            inputField.interactable = false;
        }
        //inputField.text = "Mr.WANG";
    }
}
