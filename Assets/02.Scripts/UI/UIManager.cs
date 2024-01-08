using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("_UI");
                go.AddComponent<UIManager>();
                _instance = go.GetComponent<UIManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    private void Awake()
    {
        if(_instance == null)
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

    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
