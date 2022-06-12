using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
        print("SpawningEdgeBalls");
    }

    public void SpawnGreenBalls()
    {
        print("SpawningGreenBalls");
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
