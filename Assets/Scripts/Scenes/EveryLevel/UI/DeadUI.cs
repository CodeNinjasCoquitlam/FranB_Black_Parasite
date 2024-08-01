using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadUI : MonoBehaviour
{
    [SerializeField] private Text goBackToText;

    private void Start()
    {
        goBackToText.text = "Back To Menu";
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
