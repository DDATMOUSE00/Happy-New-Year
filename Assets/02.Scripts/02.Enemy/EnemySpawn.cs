using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject enemyPrefabs;
    public int enemyCount;

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefabs);
        }
    }
}
