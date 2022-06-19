using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISecondBoss : MonoBehaviour
{
    private EnemyController myController;
    public float delayBeforeStarting = 4f;
    [Header("Long Fire")] 
    public float delayBetweenLongFires = 15f;
    public GameObject longFirePrefab;
    public float delayBeforeLongFire = 3f;
    public float timeLongFireOnField = 10f;
    public float delayBetweenLongFireHits = 0.3f;
    public float longFireDamage = 3f;
    public float lerpToPlayerIntensity = 0.1f;
    [Header("Permanent Fire")]
    public float delayBetweenPermanentFires = 3f;
    public GameObject permanentFirePrefab;
    public float delayBeforePermanentFire = 3f;
    public float delayBetweenPermanentFireHits = 0.3f;
    public float permanentFireDamage = 3f;
    public float permanentFireYOffset = 1;
    private void Start()
    {
        myController = GetComponent<EnemyController>();
        StartCoroutine(DelayBeforeStartingCoroutine());
        PlayerSpellCasting.Instance.UltimateBlock();
    }
    
    private IEnumerator DelayBeforeStartingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeStarting);
        SpawnLongFire();
        SpawnPermanentFire();
    }

    public void SpawnLongFire()
    {
        StartCoroutine(SpawnLongFireCoroutine());
    }

    public IEnumerator SpawnLongFireCoroutine()
    {
        Vector2 spawnPos = new Vector2(0, PlayerManager.Instance.transform.position.y);
        GameObject temp = Instantiate(longFirePrefab, spawnPos, Quaternion.identity);
        temp.GetComponent<Boss2Telegraph>().DelayedFireSpawn(lerpToPlayerIntensity, delayBeforeLongFire, timeLongFireOnField, longFireDamage, delayBetweenLongFireHits);
        yield return new WaitForSeconds(delayBetweenLongFires);
        SpawnLongFire();
    }

    public void SpawnPermanentFire()
    {
        StartCoroutine(SpawnPermanentFireCoroutine());
    }

    public IEnumerator SpawnPermanentFireCoroutine()
    {
        Vector2 spawnPos = new Vector2(PlayerManager.Instance.transform.position.x, PlayerManager.Instance.transform.position.y + permanentFireYOffset);
        GameObject temp = Instantiate(permanentFirePrefab, spawnPos, Quaternion.identity);
        temp.GetComponent<Boss2LongFire>().SetDelayedParameters(delayBeforePermanentFire, permanentFireDamage, delayBetweenPermanentFireHits);
        yield return new WaitForSeconds(delayBetweenPermanentFires);
        SpawnPermanentFire();
    }
}
