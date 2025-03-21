using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width}x{resolutions[i].height} {resolutions[i].refreshRate}Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        LoadSettings(currentResolutionIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", Screen.fullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingsPreference")
            ? PlayerPrefs.GetInt("QualitySettingsPreference")
            : 3;

        resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference")
            ? PlayerPrefs.GetInt("ResolutionPreference")
            : currentResolutionIndex;

        Screen.fullScreen = PlayerPrefs.HasKey("FullScreenPreference")
            ? PlayerPrefs.GetInt("FullScreenPreference") == 1
            : true;

        qualityDropdown.RefreshShownValue();
        resolutionDropdown.RefreshShownValue();
    }
}
