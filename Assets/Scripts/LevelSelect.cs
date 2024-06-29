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
            buttons[i].interactable = true;
            buttons[i].image.sprite = UnlockedButton;
            //buttons[i].FindGameObjectWithTag("Text").color = Color.white;
            //var ItsAText = buttons[i].transform.GetChild(0).gameObject;
           // ItsAText.color = Color.white;
        }
    }
   public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
