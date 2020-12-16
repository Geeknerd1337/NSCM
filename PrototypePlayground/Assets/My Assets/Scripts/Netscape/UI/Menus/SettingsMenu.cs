using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Resolution[] resolutions;
    public Dropdown resDropDown;
    public Dropdown graphicsDropdown;
    public Toggle fullscreenToggle;
    public Slider sfxSlider;
    public Slider musicSlider;
    public Slider fovSlider;
    public Text fovText;
    private float fov;

    public float FOV
    {
        get
        {
            return fov;
        }
    }
    private LevelSaveDataController dataController;
    private void Start()
    {

        //Populate the drop down with all the resolutions
        resolutions = Screen.resolutions;
        resDropDown.ClearOptions();

        List<string> options = new List<string>();
        int currResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
            {
                currResolutionIndex = i;
            }
            string option = resolutions[i].width.ToString() + " X " + resolutions[i].height.ToString();
            options.Add(option);
        }

        resDropDown.AddOptions(options);
        resDropDown.value = currResolutionIndex;
        resDropDown.RefreshShownValue();
        float value;
        bool result = mixer.GetFloat("SFXvolume", out value);
        if (result)
        {
            sfxSlider.value = value;
        }
        result = mixer.GetFloat("MusicVolume", out value);
        if (result)
        {
            musicSlider.value = value;
        }

        fovText.text = "60";
        dataController = FindObjectOfType<LevelSaveDataController>();
        SetSettings();
    }


    public void SetVolume(float f)
    {
        mixer.SetFloat("SFXvolume", f);
    }

    public void SetMusicVolume(float f)
    {
        mixer.SetFloat("MusicVolume", f);
    }

    public void SetQuality(int i)
    {
        QualitySettings.SetQualityLevel(i);
    }

    public void SetFullScreen(bool b)
    {
        Screen.fullScreen = b;
    }

    public void SetResolution(int i)
    {
        Resolution r = resolutions[i];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void SetFOV(float f)
    {
        fov = Mathf.Round(f);
        fovText.text = (60f + Mathf.Round(f)).ToString();
        SaveLoadSettingManager.FOV = fov;
    }
    public void SetSettings()
    {
        SaveLoadSettingManager.Load();
        if (SaveLoadSettingManager.HasValidData)
        {
            var data = SaveLoadSettingManager.Data;
            fovSlider.value = data.fov;
            musicSlider.value = data.musicVolume;
            sfxSlider.value = data.sfxVolume;
            resDropDown.value = data.resolutionSelectionIndex;
            graphicsDropdown.value = data.graphicsSelection;
            fullscreenToggle.isOn = data.fullscreen;
            

        }
    }

    public void SaveSettings()
    {
        //LevelSaveDataController saveController = FindObjectOfType<LevelSaveDataController>();
        SettingsSaveLoadData data = new SettingsSaveLoadData();
        data.fov = fov;
        data.graphicsSelection = QualitySettings.GetQualityLevel();
        data.resWidth = resolutions[resDropDown.value].width;
        data.resHeight = resolutions[resDropDown.value].height;
        data.resolutionSelectionIndex = resDropDown.value;
        data.fullscreen = Screen.fullScreen;
        data.musicVolume = musicSlider.value;
        data.sfxVolume = sfxSlider.value;

        dataController.SaveSettings(data);
    }
}
