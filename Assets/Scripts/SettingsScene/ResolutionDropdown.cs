using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionDropdown : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolution;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        GetResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void GetResolution()
    {
        resolution = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;

        for (int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + " x " + resolution[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolution[i].width == Screen.currentResolution.width &&
                resolution[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void ChangeResolution(int resolutionIndex)
    {
        Resolution res = resolution[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
