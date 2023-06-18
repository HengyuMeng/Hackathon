using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    public Text voiceoverText;
    public GameObject SuspectBox;
    public GameObject PlayerBox;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(VoiceOver voiceover)
    {
        Debug.Log("Starting dialogue.......");
        // SuspectBox.SetActive(true);
        sentences.Clear();
        foreach (string sentence in voiceover.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //voiceoverText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        voiceoverText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            voiceoverText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of the dialogue...");
        SuspectBox.SetActive(false);
        PlayerBox.SetActive(true);
    }
}
