using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timeForNextSpawn;
    public GameObject EnemyPrefab;


    void Start()
    {
        timeForNextSpawn = Time.time + Random.Range(1, 10);
    }


    void Update()
    {
        SpawnEnemy();
    }

    //Spawns an enemy at a random time between 1 and 20 seconds.
    void SpawnEnemy()
    {
        if (Time.time > timeForNextSpawn)
        {
            Instantiate(EnemyPrefab, gameObject.transform);
            timeForNextSpawn = Time.time + Random.Range(1, 20);
        }
    }
}