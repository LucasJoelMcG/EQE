using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("level", 3);
    }
}
