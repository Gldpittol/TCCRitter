using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DungeonSelectTrigger : MonoBehaviour
{
    private bool isCollidingWithPlayer;
    public GameObject selectDungeonScreen;
    private void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.F) && GameManager.Instance.gameState == GameState.Gameplay)
        {
            selectDungeonScreen.SetActive(true);
            CameraManager.Instance.FinishLerp();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            PlayerMovement.Instance.ChangeFKeyVisibility(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            PlayerMovement.Instance.ChangeFKeyVisibility(false);
        }
    }
}
