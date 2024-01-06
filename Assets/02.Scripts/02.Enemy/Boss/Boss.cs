using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Health health;
    [SerializeField] private GameObject stone;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        Pattern();
    }

    private void Pattern()
    {
        Vector3 originPosition = stone.transform.position;
        int randX = Random.Range(0, 39);
        Vector3 RandomPostion = new Vector3(randX, 0, 0);
        Vector3 respawnPosition = originPosition + RandomPostion;

        Instantiate(stone, respawnPosition, Quaternion.identity);
    }

}
