﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextSceneName;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
