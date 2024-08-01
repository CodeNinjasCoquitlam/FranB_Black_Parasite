using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArenaEnd : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Prototype()
    {
        Time.timeScale = 1;
        UnlockedPrototype();
        gameManager.SaveValues();
        Time.timeScale = 1;
        Invoke("LoadNextLevel", 1.5f);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        UnlockedPrototype();
        gameManager.SaveValues();
        Time.timeScale = 1;
        Invoke("LoadMenu", 1.5f);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        UnlockedPrototype();
        gameManager.SaveValues();
        Time.timeScale = 1;
        Invoke("ActuallyQuit", 1.5f);
    }

    void UnlockedPrototype()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 5);
            PlayerPrefs.Save();
            print("Now: " + PlayerPrefs.GetInt("UnlockedLevel"));
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Prototype");
    }

    public void ActuallyQuit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    void Update()
    {
        if(gameObject.activeInHierarchy == true)
        {
            UnlockedPrototype();
        }
    }
}