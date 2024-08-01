using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings2 : MonoBehaviour
{
    [SerializeField] private GameObject Panel1;
    [SerializeField] private GameObject Panel2;
    [SerializeField] private GameObject Panel3;

    [SerializeField] private Text vSyncText;

    [SerializeField] private Text sliderWholeNumbersText;

    void Start()
    {
        if (PlayerPrefs.GetString("SliderWholeNumbers") == "False")
        {
            sliderWholeNumbersText.text = "False";
            PlayerPrefs.SetString("SliderWholeNumbers", "False");
        }
        else
        {
            if (PlayerPrefs.GetString("SliderWholeNumbers") == "True")
            {
                sliderWholeNumbersText.text = "True";
                PlayerPrefs.SetString("SliderWholeNumbers", "True");
            }
        }
        
        if (PlayerPrefs.GetInt("VSyncCount") == 0)
        {
            QualitySettings.vSyncCount = 0;
            vSyncText.text = "False";
            PlayerPrefs.SetInt("VSyncCount", 0);
        }
        else
        {
            QualitySettings.vSyncCount = 1;
            vSyncText.text = "True";
            PlayerPrefs.SetInt("VSyncCount", 1);
        }
    }

    public void OpenSettings1()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }

    public void OpenSettings3()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
    }

    public void VSyncToggle()
    {
        if(QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;
            vSyncText.text = "True";
            PlayerPrefs.SetInt("VSyncCount", 1);
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vSyncText.text = "False";
            PlayerPrefs.SetInt("VSyncCount", 0);
        }
    }

    public void SliderwholeNumbersToggle()
    {
        if(sliderWholeNumbersText.text == "False")
        {
            sliderWholeNumbersText.text = "True";
            PlayerPrefs.SetString("SliderWholeNumbers", "True");
        }
        else
        {
            sliderWholeNumbersText.text = "False";
            PlayerPrefs.SetString("SliderWholeNumbers", "False");
        }
    }
}
