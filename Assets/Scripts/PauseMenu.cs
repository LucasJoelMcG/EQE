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
    [SerializeField] private GameObject opcionCanvas;

    void Awake()
    {
        playerControls = new PlayerInputsAction();
        pauseUI.SetActive(false);
        opcionCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        isPaused = false;
        AudioListener.pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpcionMenu()
    {
        opcionCanvas.SetActive(true);
        pauseUI.SetActive(false) ;

    }
    
    public void QuitGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
        Loader.Load(Loader.Scene.MapScene);
    }
}
