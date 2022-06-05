using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDungeonManager : MonoBehaviour
{
    public bool startedOnce = false;

    private void OnEnable()
    {
        if (!startedOnce) return;
        Time.timeScale = 0f;
        GameManager.Instance.gameState = GameState.Cutscene;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        GameManager.Instance.gameState = GameState.Cutscene;
        startedOnce = true;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        GameManager.Instance.gameState = GameState.Gameplay;
    }
}
