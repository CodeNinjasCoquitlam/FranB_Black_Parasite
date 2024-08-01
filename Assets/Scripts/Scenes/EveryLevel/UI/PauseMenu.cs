using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Slider volumeMusicSlider;
    [SerializeField] AudioMixer musicMixer;

    [SerializeField] Slider volumeSFXSlider;
    [SerializeField] AudioMixer sfxMixer;

    [SerializeField] private Text sfxText;
    [SerializeField] private Text musicText;

    public GameObject pauseMenu;

    [SerializeField] private Text goBackToText;

    [SerializeField] private GameObject music;

    private void Start()
    {
        ChangeVolumeMusic(PlayerPrefs.GetFloat("SavedMasterVolumeMusic", 100));
        ChangeVolumeSFX(PlayerPrefs.GetFloat("SavedMasterVolumeSFX", 100));

        goBackToText.text = "Back To Menu";
    }

    public void Resume()
    {
        music.SetActive(true);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
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
}
