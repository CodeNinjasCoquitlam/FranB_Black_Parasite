using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Diagnostics;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.GetInt("CoinsPerCoin") == 0)
        {
            PlayerPrefs.SetInt("CoinsPerCoin", 1);
        }
        if (PlayerPrefs.GetInt("MaxAmmo") == 0)
        {
            PlayerPrefs.SetInt("MaxAmmo", 5);
        }
        if (PlayerPrefs.GetString("GunUpgrade") == "")
        {
            PlayerPrefs.SetString("GunUpgrade", "Laser Gun");
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
