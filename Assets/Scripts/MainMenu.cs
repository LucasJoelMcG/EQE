using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadScene()
    {
        Loader.Load(Loader.Scene.MapScene);
    }

    public void LoadSettings()
    {
        Loader.Load(Loader.Scene.SettingsScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
