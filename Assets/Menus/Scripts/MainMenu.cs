using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject controls;

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Controls() {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void Back() {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }

}
