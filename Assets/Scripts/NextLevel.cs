
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int nextSceneToLoad;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("level", nextSceneToLoad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Loader.Load(Loader.Scene.LevelResult);
    }
}
