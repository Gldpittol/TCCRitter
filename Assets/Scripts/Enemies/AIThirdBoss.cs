using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIThirdBoss : MonoBehaviour
{
    private EnemyController myController;
    private float maxHP;
    private List<Transform> movePointsList = new List<Transform>();
    private Transform currentPos;
    private bool isMoving;
    
    public float delayBeforeStarting = 4f;
    public Transform movePoints;
    public float delayBetweenMoves;
    public float moveSpeed = 10f;

    [Header("Wave")] 
    public GameObject wavePrefab;
    public float waveDamage;
    public float waveSpeed;
    public float delayBetweenWaveSpawns;
    public Transform wavesLeft;
    public Transform wavesRight;

    [Header("Tsunami")] 
    public GameObject tsunamiPrefab;
    public float delayBeforePush;
    public float pushIntensity;
    public float delayBeforeDestroyTsunami;
    public float tweenSpeed;
    public float tweenSize;
    public float animatorSpeedWhenPushing;
    public float tsunamiHpThreshold;
    public Transform tsunamiSpawnPosLeft;
    public Transform tsunamiSpawnPosRight;
    
    [Header("Donut")] 
    public GameObject donutPrefab;
    public float donutDamage;
    public float delayBetweenDonuts;
    public float delayUntilNewDonutIsCast;
    public float donutHpThreshold = 0.3f;


    private void Start()
    {
        wavesLeft.transform.parent = null;
        wavesRight.transform.parent = null;
        movePoints.transform.parent = null;
        tsunamiSpawnPosLeft.transform.parent = null;
        tsunamiSpawnPosRight.transform.parent = null;
            
        myController = GetComponent<EnemyController>();
        maxHP = myController.health;
        foreach (Transform child in movePoints)
        {
            movePointsList.Add(child);
        }
        StartCoroutine(DelayBeforeStartingCoroutine());
        PlayerSpellCasting.Instance.UltimateBlock();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(isMoving)
            PlayerCollision.Instance.PlayerTakeDamage(myController.baseDamage);
        }
    }

    public float GetHpPercentage()
    {
        return myController.health / maxHP;
    }

    private IEnumerator DelayBeforeStartingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeStarting);
        MoveToNewPos();
        SpawnWaves();
        SpawnDonut();
    }

    public void MoveToNewPos()
    {
        StartCoroutine(MoveToNewPosCoroutine());
    }

    public IEnumerator MoveToNewPosCoroutine()
    {
        Transform newPos = movePointsList[Random.Range(0, movePointsList.Count)];
        if (currentPos && newPos == currentPos)
        {
            MoveToNewPos();
            yield break;
        }

        isMoving = true;
        while (Vector2.Distance(transform.position, newPos.position) > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, newPos.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        currentPos = newPos;
        isMoving = false;
        yield return new WaitForSeconds(delayBetweenMoves);
        MoveToNewPos();
    }

    public void SpawnWaves()
    {
        StartCoroutine(SpawnWavesCoroutine());
    }

    public IEnumerator SpawnWavesCoroutine()
    {
        bool isLeft = Random.value < 0.5f;

        List<Transform> tempList = new List<Transform>();

        foreach (Transform child in isLeft? wavesLeft : wavesRight)
        {
            tempList.Add(child);
        }

        if (GetHpPercentage() < 0.3)
        {
            tempList.RemoveAt(Random.Range(0, tempList.Count));
        }
        else if (GetHpPercentage() < 0.6)
        {
            tempList.RemoveAt(Random.Range(0, tempList.Count));
            tempList.RemoveAt(Random.Range(0, tempList.Count));
        }
        else
        {
            tempList.RemoveAt(Random.Range(0, tempList.Count));
            tempList.RemoveAt(Random.Range(0, tempList.Count));
        }

        if (GetHpPercentage() < tsunamiHpThreshold)
        {
            Vector2 tsunamiSpawnPos = isLeft ? tsunamiSpawnPosLeft.position : tsunamiSpawnPosRight.position;
            GameObject temp = Instantiate(tsunamiPrefab, tsunamiSpawnPos, Quaternion.identity);
            temp.GetComponent<Tsunami>().Initialize(delayBeforePush, !isLeft, pushIntensity, delayBeforeDestroyTsunami,
                tweenSpeed, tweenSize, animatorSpeedWhenPushing);
        }

        foreach (Transform wave in tempList)
        {
            GameObject temp = Instantiate(wavePrefab, wave.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(isLeft ? -1 : 1, 0) * waveSpeed;
            temp.GetComponent<Wave>().damage = waveDamage;
        }

        yield return new WaitForSeconds(delayBetweenWaveSpawns);
        SpawnWaves();
    }

    public void SpawnDonut()
    {
        StartCoroutine(SpawnDonutCoroutine());
    }

    public IEnumerator SpawnDonutCoroutine()
    {
        while (GetHpPercentage() > donutHpThreshold)
        {
            yield return null;
        }
        
        print("SpawningDonut");
        
        GameObject temp = Instantiate(donutPrefab, Vector2.zero, Quaternion.identity);
        temp.GetComponent<Donut>().Initialize(delayBetweenDonuts, donutDamage, delayBetweenDonuts);
        yield return new WaitForSeconds(delayUntilNewDonutIsCast);
        SpawnDonut();
    }
}
