using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings3 : MonoBehaviour
{
    [SerializeField] private Text reduceLagToggleText;

    [SerializeField] private Text fpsTextChangeTime;
    [SerializeField] private Slider fpsTextChangeTimeSlider;

    void Start()
    {
        if(PlayerPrefs.GetString("ReduceLag") == "True")
        {
            PlayerPrefs.SetString("ReduceLag", "True");
            reduceLagToggleText.text = "True";
        }
        else
        {
            PlayerPrefs.SetString("ReduceLag", "False");
            reduceLagToggleText.text = "False";
        }

        if(PlayerPrefs.GetFloat("FPSTextChange") == 0)
        {
            PlayerPrefs.SetFloat("FPSTextChange", 0.25f);
        }
        else
        {
            fpsTextChangeTime.text = "Update FPS Text: " + PlayerPrefs.GetFloat("FPSTextChange");
            fpsTextChangeTimeSlider.value = PlayerPrefs.GetFloat("FPSTextChange");
        }

    }
    
    void Update()
    {
        if (fpsTextChangeTimeSlider.value == 0 || PlayerPrefs.GetFloat("FPSTextChange") == 0)
        {
            PlayerPrefs.SetFloat("FPSTextChange", 1f);
        }
    }

    public void ReduceLagToggle()
    {
        if (PlayerPrefs.GetString("ReduceLag") == "True")
        {
            PlayerPrefs.SetString("ReduceLag", "False");
            reduceLagToggleText.text = "False";
        }
        else
        {
            PlayerPrefs.SetString("ReduceLag", "True");
            reduceLagToggleText.text = "True";
        }
    }

    public void FPSSliderTextChange(float value)
    {
        if(value != 0)
        {
            PlayerPrefs.SetFloat("FPSTextChange", value);
            fpsTextChangeTime.text = "Update FPS Text: " + value;
        }
    }
}
