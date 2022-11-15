using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject controls;
    public GameObject credits;
    GameObject levelChanger;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
    }

    public void StartGame() {
        FindObjectOfType<AudioManager>().Stop("Zumbis de março");
        levelChanger.GetComponent<LevelChanger>().LoadNextLevel();
    }

    public void Controls() {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }

    public void Credits() {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void ControlsBack() {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }

    public void CreditsBack() {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }

}
