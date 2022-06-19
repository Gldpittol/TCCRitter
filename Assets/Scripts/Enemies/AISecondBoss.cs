using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISecondBoss : MonoBehaviour
{
    private EnemyController myController;
    [Header("Long Fire")]
    public GameObject longFirePrefab;
    public float delayBeforeLongFire = 3f;
    public float timeLongFireOnField = 10f;
    public float delayBetweenLongFireHits = 0.3f;
    public float longFireDamage = 3f;
    public float lerpToPlayerIntensity = 0.1f;
    private void Start()
    {
        myController = GetComponent<EnemyController>();
        SpawnLongFire();;
    }

    public void SpawnLongFire()
    {
        Vector2 spawnPos = new Vector2(0, PlayerManager.Instance.transform.position.y);
        GameObject temp = Instantiate(longFirePrefab, spawnPos, Quaternion.identity);
        temp.GetComponent<Boss2Telegraph>().DelayedFireSpawn(lerpToPlayerIntensity, delayBeforeLongFire, timeLongFireOnField, longFireDamage, delayBetweenLongFireHits);
    }
}
