using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;

    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void ChangeCharacter(int character)
    {
        characters[selectedCharacter].SetActive(false);
        characters[character].SetActive(true);
        selectedCharacter = character;
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
}
