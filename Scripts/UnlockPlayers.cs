using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPlayers : MonoBehaviour
{
    int unlock = 5;
    public Button[] players;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < players.Length; i++)
        {
            players[i].interactable = false;
            if(GameManager.currentLevelIndex > i * unlock)
            {
                players[i].interactable = true;
            }
        }
    }
}
