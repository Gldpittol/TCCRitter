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

    private void Awake()
    {
        Instance = this;
        foreach (Transform child in transform)
        {
            enemySpawnerList.Add(child.gameObject.GetComponent<EnemySpawner>());
        }

        foreach (EnemySpawner spawner in enemySpawnerList)
        {
            GameObject temp = Instantiate(spawner.possibleEnemies[Random.Range(0, enemySpawnerList.Count)].enemy, spawner.transform.position, Quaternion.identity);
            enemiesSpawned.Add(temp);
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
            if (enemiesSpawned.Count == 0)
            {
                Door.Instance.OpenDoor();
            }
        }
    }
    
}
