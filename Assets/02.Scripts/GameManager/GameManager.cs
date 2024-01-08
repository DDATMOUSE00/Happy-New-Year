using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    
    //private Health PlayerHealth;
    //public bool Alive = true;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                _instance = go.GetComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    public Exp exp;
    public int experience;

    public GameObject GameOverPanel;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
            if (SceneManager.GetActiveScene().buildIndex == 0) Destroy(this);
        }
    }

    private void Update()
    {
        if (experience >= 1)
        {
            SetExp();
        }
    }

    void SetExp()
    {
        exp.GetExp(experience);
        experience = 0;
    }

    public void Gameover()
    {
        GameOverPanel.SetActive(true);
    }






}
