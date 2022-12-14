using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        Level1,
        Level2,
        Level3,
        LevelResult,
        MapScene,
        LoadingScene,
        SettingsScene, 
        MainMenu,
        GameOverScene,
        CreditsScene
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene) {
        // After the laoding scene end loading, execute  the callback
        onLoaderCallback = () => {
            SceneManager.LoadScene(scene.ToString());
        };
        // Load the loading scene
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback() {
        // Triggered after the first update wich lets the screen refresh
        if (onLoaderCallback != null) {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
