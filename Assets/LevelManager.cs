using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;

    public static LevelManager instance;
    public GameObject pausePanel;
    public GameObject levelEndPanel;
    public GameObject endGamePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        currentLevel = DataHolder.instance.currentLevel;
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        levelEndPanel.SetActive(false);
        endGamePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void EndLevel()
    {
        print("cabou");
        Time.timeScale = 0;

        if (currentLevel == MusicPlayer.instance.musicToPlay.tracks.Count)
        {
            endGamePanel.SetActive(true);
        }
        else {
            currentLevel = 1;
            DataHolder.instance.UpdateHoldingData();
            levelEndPanel.SetActive(true);
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(!pausePanel.activeInHierarchy);
        Time.timeScale = 1 - Time.timeScale;
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void NextLevel()
    {
        currentLevel++;
        DataHolder.instance.UpdateHoldingData();
        SceneManager.LoadScene("TestScene-Music");
    }


    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
