using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private PlayerControls playerControls;
    private InputAction menu;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;

    void Awake() {
        playerControls = new PlayerControls();
    }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable() {
        menu = playerControls.Menu.Pause;
        menu.Enable();

        menu.performed += Pause;
    }

    void OnDisable() {
        menu.Disable();
    }

    void Pause(InputAction.CallbackContext context) {
        isPaused = !isPaused;

        if(isPaused) {
            ActivateMenu();
        } else {
            DeactivateMenu();
        }
    }

    void ActivateMenu() {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
    }

    public void DeactivateMenu() {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
}
