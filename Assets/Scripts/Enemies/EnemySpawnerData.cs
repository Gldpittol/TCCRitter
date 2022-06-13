using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemySpawnerData : ScriptableObject
{
    [System.Serializable]
    public struct EnemyStruct
    {
        public GameObject enemy;
        public int minimumFloorToSpawn;
    }

    public EnemyStruct[] possibleEnemies;
}
