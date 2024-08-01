using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    private bool FullscreenMode;

    public Text FullscreenText;

    [SerializeField] Slider volumeMusicSlider;
    [SerializeField] AudioMixer musicMixer;

    [SerializeField] Slider volumeSFXSlider;
    [SerializeField] AudioMixer sfxMixer;

    [SerializeField] Slider FPSSlider;

    [SerializeField] private GameObject Panel1;
    [SerializeField] private GameObject Panel2;
    [SerializeField] private GameObject Panel3;

    [SerializeField] private Text sfxText;
    [SerializeField] private Text musicText;
    [SerializeField] private Text fpsText;

    void Update()
    {
        fpsText.text = "FPS: " + PlayerPrefs.GetInt("FPS");
    }
    void Start()
    {
        ChangeVolumeMusic(PlayerPrefs.GetFloat("SavedMasterVolumeMusic", 100));
        ChangeVolumeSFX(PlayerPrefs.GetFloat("SavedMasterVolumeSFX", 100));
        ChangeFPS(PlayerPrefs.GetInt("FPS", 60));
        FullscreenMode = false;
        if (PlayerPrefs.GetFloat("FullscreenMode") == 0)
        {
            FullscreenText.text = "True";
            FullscreenMode = true;
        }
        else
        {
            FullscreenText.text = "False";
            FullscreenMode = false;
        }
    }

    public void ToggleFullScreen()
    {
        FullscreenMode = !FullscreenMode;
        Screen.fullScreen = !Screen.fullScreen;
        PlayerPrefs.SetFloat("FullscreenMode", (FullscreenMode ? 0 : 1));
        FullscreenText.text = FullscreenMode.ToString();
    }

    public void ChangeVolumeSFX(float sliderValue)
    {
        if (sliderValue < 1)
        {
            sliderValue = .001f;
        }
        RefreshSFXSlider(sliderValue);
        PlayerPrefs.SetFloat("SavedMasterVolumeSFX", sliderValue);
        sfxMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue / 100) * 20f);
    }

    public void ChangeVolumeMusic(float sliderValue)
    {
        if (sliderValue < 1)
        {
            sliderValue = .001f;
        }
        RefreshMusicSlider(sliderValue);
        PlayerPrefs.SetFloat("SavedMasterVolumeMusic", sliderValue);
        musicMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue / 100) * 20f);
    }

    public void SetVolumeMusicFromSlider()
    {
        ChangeVolumeMusic(volumeMusicSlider.value);
    }

    public void SetFPSFromSlider()
    {
        int intSliderValue = (int)FPSSlider.value;
        ChangeFPS(intSliderValue);
    }

    public void SetVolumeSFXFromSlider()
    {
        ChangeVolumeSFX(volumeSFXSlider.value);
    }

    public void RefreshMusicSlider(float sliderValue)
    {
        volumeMusicSlider.value = sliderValue;
        musicText.text = "Music: " + sliderValue;
    }

    public void RefreshSFXSlider(float sliderValue)
    {
        volumeSFXSlider.value = sliderValue;
        sfxText.text = "SFX: " + sliderValue;
    }

    public void RefreshFPSSlider(float sliderValue)
    {
        FPSSlider.value = sliderValue;
    }

    public void ChangeScene(string SceneName)
    {
        Debug.Log("back button clicked!");
        SceneManager.LoadScene(SceneName);
    }

    public void ChangeFPS(int sliderValue)
    {
        Application.targetFrameRate = sliderValue;
        RefreshFPSSlider(sliderValue);
        PlayerPrefs.SetInt("FPS", sliderValue);
    }

    public void OpenSettings2()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
    }
}
