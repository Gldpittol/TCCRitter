using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Serializable]
    public struct EnemyStruct
    {
        public GameObject enemy;
        public int minimumFloorToSpawn;
    }

    public EnemyStruct[] possibleEnemies;

    public void SpawnAnEnemy()
    {
        
    }
}
