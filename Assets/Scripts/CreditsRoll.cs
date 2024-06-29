using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class CreditsRoll : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            music.pitch = 2;
            Time.timeScale = 3;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            music.pitch = 1;
            Time.timeScale = 1;
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
