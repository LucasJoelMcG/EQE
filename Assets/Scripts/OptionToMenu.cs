using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class OptionToMenu : MonoBehaviour
{
    private PlayerInputsAction playerControls;
    private InputAction menu;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject opcionCanvas;

    void Awake()
    {
        playerControls = new PlayerInputsAction();
    }
    private void OnEnable()
    {
        menu = playerControls.Menu.Menu;
        menu.Enable();

        menu.performed += Pause;
    }
    public void Pause(InputAction.CallbackContext context)
    {
        opcionCanvas.SetActive(false);
    }
    public void LoadPauseMenu()
    {
        pauseUI.SetActive(true);
        opcionCanvas.SetActive(false);
        
    }
}
