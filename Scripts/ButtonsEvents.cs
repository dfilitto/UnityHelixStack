using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonsEvents : MonoBehaviour
{
    public Button soundButton;
    public TextMeshProUGUI textButtonSound;
    public GameObject gameMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            textButtonSound.text = "/";            
        }
        else
        {
            textButtonSound.text = "";
        }
    }
    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            textButtonSound.text = "";
        }
        else
        {
            GameManager.mute = true;
            textButtonSound.text = "/";
        }
    }
    public void StartGame()
    {
        GameManager.isGameStarted = true;
        gameMenuPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
