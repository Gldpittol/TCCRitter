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
    private void Awake()
    {
        Instance = this;
    }
}
