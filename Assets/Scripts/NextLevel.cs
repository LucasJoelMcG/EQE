
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int nextSceneToLoad;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        int level = PlayerPrefs.GetInt("level", 2);
        PlayerPrefs.SetInt("level", level + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Loader.Load(Loader.Scene.LevelResult);
    }
}
