using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Interation : MonoBehaviour
{
    public bool isInteracting;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInteracting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInteracting = false;
        }
    }
}
