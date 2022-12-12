using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerInputsAction playerControls;
    private InputAction menu;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;

    void Awake()
    {
        playerControls = new PlayerInputsAction();
        pauseUI.SetActive(false);
    }

    private void OnEnable()
    {
        menu = playerControls.Menu.Menu;
        menu.Enable();

        menu.performed += Pause;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        isPaused = true;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        isPaused = false;
        AudioListener.pause = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
    }
}
