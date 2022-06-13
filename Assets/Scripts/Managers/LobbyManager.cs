using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.gameState = GameState.Gameplay;
        PlayerStats.currentHealth = 100;
        PlayerStats.currentFloor = 1;
        PlayerSpellCasting.Instance.ResetCooldowns();
        if(SaveLoadManager.Instance) SaveLoadManager.Instance.SaveGame();
    }
}
