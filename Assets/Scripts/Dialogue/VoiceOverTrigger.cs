using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public VoiceOver voiceover;
    public GameObject SuspectBox;
    public GameObject PlayerBox;

    public void TriggerDialogue()
    {
        FindObjectOfType<VoiceOverManager>().StartDialogue(voiceover);
    }
}
