using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public Transform spellSwap;
    public Transform exitDoor;

    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerStats.progress = GameProgress.Level3Clear;
                if (SaveLoadManager.Instance) SaveLoadManager.PlayerData.progress = GameProgress.Level3Clear;
            }
        }
    }
    
    private void Start()
    {
        GameManager.Instance.gameState = GameState.Gameplay;
        PlayerStats.currentHealth = 100;
        PlayerStats.currentFloor = 1;
        PlayerSpellCasting.Instance.ResetCooldowns();
        if(SaveLoadManager.Instance) SaveLoadManager.Instance.SaveGame();
        
        HUDManager.Instance.AddToInteractionIcons(spellSwap.gameObject);
        HUDManager.Instance.AddToInteractionIcons(exitDoor.gameObject);
        HUDManager.Instance.UpdateHealthBar();
        HUDManager.Instance.UpdateCoins();

        StartCoroutine(SetMusicCoroutine());
    }
    
    private IEnumerator SetMusicCoroutine()
    {
        yield return null;
        yield return null;

        AudioManager.Instance.PlayMPDMusic();
    }
}
