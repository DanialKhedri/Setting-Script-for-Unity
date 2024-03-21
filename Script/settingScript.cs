using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingScript : MonoBehaviour
{
    //Create Empty Objects
    
    #region Create Empty Objects

    public AudioMixer audioMixer;
    public TMP_Dropdown ResDropDown;
    public Resolution[] resolutions;

    #endregion


    private void Start()
    {
        resolutions = Screen.resolutions;
        ResDropDown.ClearOptions();


        //Get Resolutions of system And Set to DropDown

        List<string> options = new List<string>();

        int currentResolotion = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + " * " + resolutions[i].height);
            Debug.Log(i);
            Debug.Log(options);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolotion = i;
            }

        }

        ResDropDown.AddOptions(options);

        ResDropDown.value = currentResolotion;
        ResDropDown.RefreshShownValue();

    }



    //SetResolution
    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }


    //Set Volume
    public void SetVolume(float volume) 
    { 

        audioMixer.SetFloat("Volume", volume);

    }

    //Set Quality
    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    //SetFullScreen
    public void SetFullScreen(bool FullScreen) 
    {
        Screen.fullScreen = FullScreen; 
    }
}
