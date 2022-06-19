using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    [Header("Missiles")] 
    public float hpPercentageThreshold = 0.5f;
    public GameObject missilePrefab;
    public float missileYOffset = 0.5f;
    public float delayBetweenMissiles = 3f;
    public float missileDamage;
    public float missileSpeed;
    public Transform missileSpawnPointRight;
    public Transform missileSpawnPointLeft;

    private float maxHP;
    private void Start()
    {
        myController = GetComponent<EnemyController>();
        maxHP = myController.health;
        StartCoroutine(DelayBeforeStartingCoroutine());
        PlayerSpellCasting.Instance.UltimateBlock();
    }

    private IEnumerator DelayBeforeStartingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeStarting);
        SpawnLongFire();
        SpawnPermanentFire();
        SpawnMissile();
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

    public void SpawnMissile()
    {
        StartCoroutine(SpawnMissileCoroutine());
    }

    public IEnumerator SpawnMissileCoroutine()
    {
        while (myController.health / maxHP > hpPercentageThreshold)
        {
            yield return null;
        }
        //Vector2 spawnPos = new Vector2(PlayerManager.Instance.transform.position.x, PlayerManager.Instance.transform.position.y + missileYOffset);
        Transform pointToUse = PlayerManager.Instance.transform.position.x > transform.position.x
            ? missileSpawnPointRight
            : missileSpawnPointLeft;
        GameObject temp = Instantiate(missilePrefab, pointToUse.position, Quaternion.identity);
        temp.GetComponent<Boss2Missile>().damage = missileDamage;
        temp.GetComponent<Rigidbody2D>().velocity = (pointToUse.position - PlayerManager.Instance.transform.position).normalized * -1 * missileSpeed;
        
        RotateTowardsPoint(180,temp, pointToUse.gameObject);
        
        yield return new WaitForSeconds(delayBetweenMissiles);
        SpawnMissile();
    }
    
    private void RotateTowardsPoint(float angleOffset, GameObject objectToRotate, GameObject point)
    {
        Vector2 spawnPos = Camera.main.WorldToViewportPoint (point.transform.position);
        Vector2 playerPos = (Vector2) PlayerManager.Instance.transform.position;
        float angle = AngleBetweenTwoPoints(spawnPos, playerPos);
        objectToRotate.transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle + angleOffset));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
