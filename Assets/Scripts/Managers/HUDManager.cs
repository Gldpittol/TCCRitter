using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private TextMeshProUGUI healthText;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthText()
    {
        healthText.text = "Health: " + PlayerStats.currentHealth.ToString("F0");
    }
}
