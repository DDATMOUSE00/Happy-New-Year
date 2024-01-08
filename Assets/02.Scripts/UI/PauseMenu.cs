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
        SceneManager.LoadScene("LHTestScene");
    }

    public void ToSettingMenu()
    {
        pauseMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void BackToPauseB()
    {
        settingPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void ToMain()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("LHScene");
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
