using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class EnemySpawnerManager : MonoBehaviour
{
    public static EnemySpawnerManager Instance;
    
    private List<EnemySpawner> enemySpawnerList = new List<EnemySpawner>();
    public List<GameObject> enemiesSpawned = new List<GameObject>();

    private bool doorOpen = false;

    private void Awake()
    {
        Instance = this;
        foreach (Transform child in transform)
        {
            enemySpawnerList.Add(child.gameObject.GetComponent<EnemySpawner>());
        }

        SpawnEnemies();
    }

    private void Update()
    {
        if (AmountOfEnemiesRemaining() == 0 && !doorOpen)
        {
            Door.Instance.OpenDoor();
            doorOpen = true;
        }
    }

    public int AmountOfEnemiesRemaining()
    {
        return enemiesSpawned.Count;
    }

    public void RemoveFromRemainingEnemiesList(GameObject enemy)
    {
        if (enemiesSpawned.Contains(enemy))
        {
            enemiesSpawned.Remove(enemy);
        }
    }
    
    private void SpawnEnemies()
    {
        if (enemySpawnerList.Count == 0) return;
        int spawnedAmount = 0;
        while (spawnedAmount < PlayerStats.currentFloor)
        {
            int rnd = Random.Range(0, enemySpawnerList.Count);
            EnemySpawner spawner = enemySpawnerList[rnd];
            GameObject temp = Instantiate(spawner.possibleEnemies[Random.Range(0, enemySpawnerList.Count)].enemy, spawner.transform.position, Quaternion.identity);
            enemiesSpawned.Add(temp);
            enemySpawnerList.Remove(spawner);
            spawnedAmount++;
        }
    }
}
