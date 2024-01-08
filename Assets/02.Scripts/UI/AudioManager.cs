using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.volume = 1f;
        audioSource.Play();

    }
}
