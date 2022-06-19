using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public Transform spellSwap;
    public Transform exitDoor;
    
    private void Start()
    {
        GameManager.Instance.gameState = GameState.Gameplay;
        PlayerStats.currentHealth = 100;
        PlayerStats.currentFloor = 1;
        PlayerSpellCasting.Instance.ResetCooldowns();
        if(SaveLoadManager.Instance) SaveLoadManager.Instance.SaveGame();
        
        HUDManager.Instance.AddToInteractionIcons(spellSwap.gameObject);
        HUDManager.Instance.AddToInteractionIcons(exitDoor.gameObject);

        StartCoroutine(SetMusicCoroutine());
    }
    
    private IEnumerator SetMusicCoroutine()
    {
        yield return null;
        yield return null;

        AudioManager.Instance.PlayMPDMusic();
    }
}
