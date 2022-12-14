using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSceneUI : MonoBehaviour
{
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
}
