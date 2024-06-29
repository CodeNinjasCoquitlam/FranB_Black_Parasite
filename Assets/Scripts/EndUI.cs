using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private Text bonusLivesText;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if(gameManager.Lives == 1)
        {
            bonusLivesText.text = "You survived with 1 life so you get 50 coins!(fifty)";
            gameManager.Coins = gameManager.Coins + 50;
        }
        if (gameManager.Lives == 2)
        {
            bonusLivesText.text = "You survived with 2 lives so you get 100 coins(one hundred)!";
            gameManager.Coins = gameManager.Coins + 100;
        }
        if (gameManager.Lives == 3)
        {
            bonusLivesText.text = "You survived with 3 lives so you get 150 coins(one hundred fifty)!";
            gameManager.Coins = gameManager.Coins + 150;
        }
    }

    public void NextLevel()
    {
        UnlockedNewLevel();
        gameManager.SaveValues();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        Invoke("LoadNextLevel", 1.5f);
    }

    public void BackToMenu()
    {
        UnlockedNewLevel();
        gameManager.SaveValues();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        Invoke("LoadMenu", 1.5f);
    }

    public void Quit()
    {
        UnlockedNewLevel();
        gameManager.SaveValues();
        Time.timeScale = 1;
        Invoke("ActuallyQuit", 1.5f);
    }

    void UnlockedNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel") + 1);
            PlayerPrefs.Save();
            print("Now: " + PlayerPrefs.GetInt("UnlockedLevel"));
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ActuallyQuit()
    {
        Application.Quit();
    }
}
