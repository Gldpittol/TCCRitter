using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class AIFirstBoss : MonoBehaviour
{
    public GameProgress progressWhenKilled = GameProgress.Boss1Clear;
    private EnemyController myController;
    public float delayBeforeStarting;
    public float cooldownEdgeBalls = 3f;
    public float cooldownGreenBalls = 5f;
    public float HpPercentageToSpawnGreenBalls = 0.5f;
    public float purpleOrbsDamage;
    public float greenOrbsDamage;
    private float currentCooldownEdgeBalls;
    private float currentCooldownGreenBalls;
    private float originalHealth;
    private bool isAIActive;
    private float playerDamageCooldown;
    private bool isDamagingPlayer = false;
    public GameObject purpleOrbSpawner;
    public GameObject purpleOrbPrefab;
    private bool isEven;
    public GameObject greenOrbprefab;
    public Transform greenOrbUpperLeft;
    public Transform greenOrblowerRight;
    public int greenOrbsToSpawn = 5;
    private void Awake()
    {
        myController = GetComponent<EnemyController>();
        originalHealth = myController.health;
        StartCoroutine(DelayBeforeStartingCoroutine());
    }

    private IEnumerator DelayBeforeStartingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeStarting);
        isAIActive = true;
        AttractorField.Instance.AddToList(PlayerManager.Instance.gameObject);
    }

    private void Start()
    {
        PlayerSpellCasting.Instance.UltimateBlock();
    }

    private void OnDestroy()
    {
        if (myController.health <= 0)
        {
            if ((int) PlayerStats.progress < (int)progressWhenKilled)
            {
                PlayerStats.progress = progressWhenKilled;
            }
        }
    }

    private void Update()
    {
        if (!isAIActive) return;
        ReduceCooldowns();
        if (isDamagingPlayer)
        {
            if (playerDamageCooldown <= 0)
            {
                PlayerCollision.Instance.PlayerTakeDamage(myController.baseDamage);
                playerDamageCooldown = myController.delayBetweenAttacks;
            }
        }
    }

    private void ReduceCooldowns()
    {
        currentCooldownEdgeBalls -= Time.deltaTime;
        if (currentCooldownEdgeBalls < 0)
        {
            currentCooldownEdgeBalls = cooldownEdgeBalls;
            SpawnEdgeBalls();
        }
        currentCooldownGreenBalls -= Time.deltaTime;
        if (currentCooldownGreenBalls < 0)
        {
            if (myController.health / originalHealth < HpPercentageToSpawnGreenBalls)
            {
                currentCooldownGreenBalls = cooldownGreenBalls;
                SpawnGreenBalls();
            }
        }

        playerDamageCooldown -= Time.deltaTime;
    }

    public void SpawnEdgeBalls()
    {
        foreach (Transform child in purpleOrbSpawner.transform)
        {
            if (isEven)
            {
                if (child.GetSiblingIndex() % 2 == 0)
                {
                    GameObject temp = Instantiate(purpleOrbPrefab, child.transform.position, Quaternion.identity);
                    temp.GetComponent<PurpleOrb>().damage = purpleOrbsDamage;
                }
            }
            else
            {
                if (child.GetSiblingIndex() % 2 == 1)
                {
                    GameObject temp =  Instantiate(purpleOrbPrefab, child.transform.position, Quaternion.identity);
                    temp.GetComponent<PurpleOrb>().damage = purpleOrbsDamage;
                }
            }
        }

        isEven = !isEven;
    }

    public void SpawnGreenBalls()
    {
        GameObject temp =  Instantiate(greenOrbprefab, PlayerManager.Instance.transform.position, Quaternion.identity);
        temp.GetComponent<GreenOrb>().damage = purpleOrbsDamage;

        for (int i = 0; i < greenOrbsToSpawn; i++)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(greenOrbUpperLeft.position.x, greenOrblowerRight.transform.position.x),
                Random.Range(greenOrbUpperLeft.position.y, greenOrblowerRight.transform.position.y));
            temp =  Instantiate(greenOrbprefab, randomPos, Quaternion.identity);
            temp.GetComponent<GreenOrb>().damage = purpleOrbsDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isDamagingPlayer = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isDamagingPlayer = false;
        }
    }
}
