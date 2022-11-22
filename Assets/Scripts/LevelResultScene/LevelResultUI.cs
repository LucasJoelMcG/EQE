using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelResultUI : MonoBehaviour
{
    public void Continue()
    {
        Loader.Load(Loader.Scene.MapScene);
    }
}
