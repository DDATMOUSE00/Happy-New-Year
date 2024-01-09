using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;

    public static CharacterManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("Player");
                go.AddComponent<CharacterManager>();
                _instance = go.GetComponent<CharacterManager>();
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
}
