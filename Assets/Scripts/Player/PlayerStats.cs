using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public static float movementSpeedMultiplier = 1;
    public static float damageMultiplier = 1;
    public static float invulnerabilityRemaining = 0;
    public static float currentHealth = 100;
    public static float maxHeath = 100;
    public static float coins = 1000;
    public static float currentFloor = 1;
    public static GameProgress progress = GameProgress.Boss2Clear;
    private void Awake()
    {
        if (PlayerDontDestroy.Instance && PlayerDontDestroy.Instance.gameObject != transform.parent.gameObject) return;
        Instance = this;
    }

    private void Start()
    {
        HUDManager.Instance.UpdateCoins();
    }
}
