using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        //UnityEditor.EditorApplication.isPlaying = false; // Para cerrar el editor de unity
        Application.Quit(); // Para cerrar el juego ya exportado
    }
}
