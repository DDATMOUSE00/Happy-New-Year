using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuPanel;
    public GameObject settingPanel;
    public GameObject controlPanel;
    public GameObject GameOverP;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void Restart()
    {
        GameOverP.SetActive(false);
        SceneManager.LoadScene("1-0_Town");
    }

    public void ToSettingMenu()
    {
        pauseMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void OpenConTrolP()
    {
        controlPanel.SetActive(true);
    }

    public void BackToPauseB()
    {
        settingPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void ToMain()
    {
        GameOverP.SetActive(false);
        GameIsPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
