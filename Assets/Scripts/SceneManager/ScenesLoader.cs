using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }
    public void LoadMap()
    {
        Loader.Load(Loader.Scene.MapScene);
    }

    public void LoadSettings()
    {
        Loader.Load(Loader.Scene.SettingsScene);
    }
}
