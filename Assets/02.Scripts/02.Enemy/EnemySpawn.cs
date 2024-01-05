using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject[] enemyPrefabs;
    int enemyCount;

    private void Awake()
    {
        
    }

    private void Spawn()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (enemyPrefabs[i] != null)
            {
                Instantiate(enemyPrefabs[i]);
            }
        }
    }
}
