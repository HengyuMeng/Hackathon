using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;
using UnityEngine;

public class familyScore : MonoBehaviour
{
    public Text ScoreText;
    int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 8;
        ScoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = Random.Range(6,11);
        ScoreText.text = currentScore.ToString();
    }
}
