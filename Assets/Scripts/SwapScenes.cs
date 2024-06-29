using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            MenuBGMusic.instance.GetComponent<AudioSource>().Pause();
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            MenuBGMusic.instance.GetComponent<AudioSource>().Pause();
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            MenuBGMusic.instance.GetComponent<AudioSource>().Pause();
        }
    }
}