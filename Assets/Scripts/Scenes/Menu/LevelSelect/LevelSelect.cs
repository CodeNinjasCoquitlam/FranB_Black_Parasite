using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] buttons;

    [Header("Button Sprites")]
    public Sprite UnlockedButton;
    public Sprite LockedButton;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel") == 0)
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].image.sprite = LockedButton;
           // buttons[i].FindGameObjectWithTag("Text").color = Color.white;
            //buttons[i].GetComponent<Text>().color = Color.black;
            //var ItsAText = buttons[i].transform.GetChild(0).gameObject;
            //ItsAText.color = Color.black;
        }
        for(int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true; // bad???
            buttons[i].image.sprite = UnlockedButton;
            //buttons[i].FindGameObjectWithTag("Text").color = Color.white;
            //var ItsAText = buttons[i].transform.GetChild(0).gameObject;
           // ItsAText.color = Color.white;
        }

        if (unlockedLevel >= 4)
        {
            buttons[4].interactable = true;
            buttons[4].image.sprite = UnlockedButton;
        }

        if (unlockedLevel >= 5)
        {
            buttons[5].interactable = true;
            buttons[5].image.sprite = UnlockedButton;
        }
    }

   public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
    public void LoadScene(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}
