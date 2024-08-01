using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    [SerializeField] private Text skipText;

    void Start()
    {
        Invoke("ChangeText", 4);
    }

    void ChangeText()
    {
        skipText.text = "Credits";
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
