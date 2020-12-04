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
    }


    public void SetVolume(float f)
    {
        mixer.SetFloat("volume", f);
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
}
