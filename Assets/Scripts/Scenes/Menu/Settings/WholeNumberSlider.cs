using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeNumberSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        if (PlayerPrefs.GetString("SliderWholeNumbers") == "True")
        {
            slider.wholeNumbers = true;
        }
        if (PlayerPrefs.GetString("SliderWholeNumbers") == "False")
        {
            slider.wholeNumbers = false;
        }
    }
}
