using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserSubmit : MonoBehaviour
{
    public TMP_InputField input_question;
    public GameObject SuspectBox;
    public GameObject PlayerBox;
    public Text DialogBox;
    public MyWebSocket WebSocket;
    private string[] wait = {"思考中"};


    public void SubmitQuestion()
    {
        // 发送警察问题给GPT
        WebSocket.SendWebSocketMessage(input_question.text);
        Debug.Log(input_question.text);
        WebSocket.iretation += 1;
        // 清空文本框，转换为犯人回答
        PlayerBox.SetActive(false);
        input_question.text="";
        DialogBox.text = "思考中...";
        SuspectBox.SetActive(true);


    }
    
    public void Answer()
    {
        var totalMassage = WebSocket.MessageList[WebSocket.iretation-1];
        var massageBlocks = totalMassage.Split(Convert.ToChar("。"));
        SuspectBox.GetComponent<VoiceOverTrigger>().voiceover.sentences = massageBlocks;
    }
}
