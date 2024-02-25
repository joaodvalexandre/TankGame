﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle fpsToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antiAliasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider soundSlider;
    public Button applyButton;
    public Button applyButton2;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;
    public GameObject menu;
    
    private string scr = 'FPSDiplay';

    void Start()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        fpsToggle.onValueChanged.AddListener(delegate { OnFpsToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antiAliasingDropdown.onValueChanged.AddListener(delegate { OnAntiAliasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        soundSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
        applyButton2.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        gameSettings.isFullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnFpsToggle()
    {
        if ((menu.GetComponent(scr) as MonoBehaviour).enabled)
        {
            gameSettings.isFps = (menu.GetComponent(scr) as MonoBehaviour).enabled = false;
        }
        else
        {
            gameSettings.isFps = (menu.GetComponent(scr) as MonoBehaviour).enabled = true;
        }
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
        gameSettings.textureQuality = textureQualityDropdown.value;
        QualitySettings.SetQualityLevel(gameSettings.textureQuality);
    }

    public void OnAntiAliasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antiAliasing = (int)Mathf.Pow(2, antiAliasingDropdown.value);
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnMusicVolumeChange()
    {
        musicSource.volume = gameSettings.soundVolume = soundSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        fullscreenToggle.isOn = gameSettings.isFullscreen;
        fpsToggle.isOn = gameSettings.isFps;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        textureQualityDropdown.value = gameSettings.textureQuality;
        antiAliasingDropdown.value = gameSettings.antiAliasing;
        vSyncDropdown.value = gameSettings.vSync;
        soundSlider.value = gameSettings.soundVolume;

        resolutionDropdown.RefreshShownValue();
    }
}