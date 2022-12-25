using UnityEngine;

public class LevelResultUI : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Continue()
    {
        Loader.Load(Loader.Scene.MapScene);
    }
}
