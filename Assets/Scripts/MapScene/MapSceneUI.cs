using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSceneUI : MonoBehaviour
{
    public Image dropdown;
    public Button settingsButton;
    public Button menuButton;
    public bool showDropdown;
    public Button[] levelsButtons;

    private void Start()
    {
        for (int i = 0; i < levelsButtons.Length; i++)
        {
            int level = PlayerPrefs.GetInt("level", 0);
            Debug.Log("level" + level);
            Debug.Log("i" + i);
            if (i > level)
            {
                levelsButtons[i].interactable = false;
            }
        }
    }

    public void LoadLevel1()
    {
        Loader.Load(Loader.Scene.Level1);
    }

    public void LoadLevel2()
    {
        Loader.Load(Loader.Scene.Level2);
    }

    public void LoadLevel3()
    {
        Loader.Load(Loader.Scene.Level3);
    }

    public void LoadSettings()
    {
        Loader.Load(Loader.Scene.SettingsScene);
    }

    public void LoadMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

    public void ManageDropdown()
    {
        if (showDropdown)
        {
            dropdown.gameObject.SetActive(true);
            settingsButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        else
        {
            dropdown.gameObject.SetActive(false);
            settingsButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
        }
        showDropdown = !showDropdown;
    }
}
