using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInfoUI : MonoBehaviour
{
    public TMP_Text descriptionText;
    public Image objectImage;
    public Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseInfoPanel);
        gameObject.SetActive(false);
    }

    public void DisplayInfo(string description, Sprite sprite)
    {
        descriptionText.text = description;
        objectImage.sprite = sprite;
        gameObject.SetActive(true);
    }

    private void CloseInfoPanel()
    {
        gameObject.SetActive(false);
    }
}
