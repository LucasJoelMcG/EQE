using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        Loader.Load(Loader.Scene.MapScene);
    }
}
