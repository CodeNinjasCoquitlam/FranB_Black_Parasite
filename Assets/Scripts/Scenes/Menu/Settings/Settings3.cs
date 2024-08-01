using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings3 : MonoBehaviour
{
    [SerializeField] private Text reduceLagToggleText;
    [SerializeField] private Text resetDataText;

    [SerializeField] private Text fpsTextChangeTime;
    [SerializeField] private Slider fpsTextChangeTimeSlider;

    private int resetClicks = 0;


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

    public void ResetData()
    {
        if(resetClicks == 0)
        {
            resetDataText.text = "Click one more time to reset data.";
            Invoke("resetclick1", 1);
        }
        if(resetClicks == 1)
        { 
            resetClicks = 0;
            PlayerPrefs.SetInt("Coins", 0);
            PlayerPrefs.SetInt("MaxAmmo", 5);
            PlayerPrefs.SetInt("CoinsPerCoin", 1);
            PlayerPrefs.SetString("GunUpgrade", "Laser Gun");
            PlayerPrefs.SetString("NextGunUpgrade", "Shotgun");
            PlayerPrefs.SetInt("CPCNUN", 1);
            PlayerPrefs.SetInt("MANUN", 1);
            PlayerPrefs.SetInt("GUNUN", 1);
            PlayerPrefs.SetInt("CPCCP", 73);
            PlayerPrefs.SetInt("MACP", 100);
            PlayerPrefs.SetInt("GUCP", 200);
            PlayerPrefs.SetInt("UnlockedLevel", 0);
            resetDataText.text = "Close the game for the changes to apply.";
            Invoke("textBack", 2.5f);
        }
    }

    void textBack()
    {
        resetDataText.text = "Reset Data";
    }

    void resetclick1()
    {
        resetClicks = 1;
    }
}
