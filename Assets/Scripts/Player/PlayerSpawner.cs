using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> playerSpawnPoints = new List<GameObject>();
    public GameObject playerPrefab;
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            playerSpawnPoints.Add(child.gameObject);
        }
        
        if (!PlayerDontDestroy.Instance)
        {
            Instantiate(playerPrefab, playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform.position, Quaternion.identity);
            PlayerDontDestroy.Instance.Respawn();
        }
        else
        {
            PlayerDontDestroy.Instance.transform.position =
                playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform.position;
            PlayerDontDestroy.Instance.Respawn();
        }
    }
}
