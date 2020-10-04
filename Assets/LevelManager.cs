using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;

    public static LevelManager instance;
    public GameObject pausePanel;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        pausePanel.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void EndLevel() {
        print("cabou");
        Time.timeScale = 0;
    }

    public void PauseGame() {
        pausePanel.SetActive(!pausePanel.activeInHierarchy);
        Time.timeScale = 1 - Time.timeScale;
    }

    public void QuitGame() {
        Application.Quit(0);
    }
}
