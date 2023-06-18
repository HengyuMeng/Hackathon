using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NativeWebSocket;
using TMPro;

public class MyWebSocket : MonoBehaviour
{
    public WebSocket websocket;
    public GameObject SuspectBox;
    public UserSubmit messageRespondent;
    public List<string> MessageList;
    public int iretation;

    // Start is called before the first frame update
    async void Start()
    {
        websocket = new WebSocket("ws://10.252.5.79:9000/gpt/crime");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {
            Debug.Log("OnMessage!");
            Debug.Log(bytes);
            
            // getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            MessageList.Add(message);
            // 回调完成后调用，显示犯人的回答
            messageRespondent.Answer();
            SuspectBox.GetComponent<VoiceOverTrigger>().TriggerDialogue();

            // Debug.Log("OnMessage! " + message);
        };

        // waiting for messages
        await websocket.Connect();
    }

    // Update is called once per frame

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
    }
    
    public async void SendWebSocketMessage(string text)
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText(text);
        }
    }
    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
    
}
