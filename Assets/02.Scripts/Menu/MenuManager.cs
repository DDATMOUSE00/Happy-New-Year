using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingMenu;
    
    void Start()
    {
        
    }

    
    public void Play()
    {
        SceneManager.LoadScene("LHTestScene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void SettingMenu()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
}
