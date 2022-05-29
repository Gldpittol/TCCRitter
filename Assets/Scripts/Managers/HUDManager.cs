using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private GameObject hpBar;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Image basicFill;
    [SerializeField] private Image offensiveFill;
    [SerializeField] private Image defensiveFill;
    [SerializeField] private Image ultimateFill;
    [SerializeField] private Image basicSprite;
    [SerializeField] private Image offensiveSprite;
    [SerializeField] private Image defensiveSprite;
    [SerializeField] private Image ultimateSprite;

    private float hpBarOriginalScaleX;
    private void Awake()
    {
        hpBarOriginalScaleX = hpBar.transform.localScale.x;
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if (pauseMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
                GameManager.Instance.gameState = GameState.Paused;
                PlayerMovement.Instance.ActivatePause();
            }
            else 
            {
                Time.timeScale = 1;
                GameManager.Instance.gameState = GameState.Gameplay;
            }
        }
    }

    public void UpdateHealthBar()
    {
        float scaleX = PlayerStats.currentHealth / PlayerStats.maxHeath * hpBarOriginalScaleX;
        hpBar.transform.localScale = new Vector2(scaleX, hpBar.transform.localScale.y);
    }

    public void UpdateCooldownFill(float current, float max, MagicType type)
    {
        if (current < 0) current = 0;

        float fillRatio = current / max;

        switch (type)
        {
            case MagicType.Basic:
                basicFill.fillAmount = fillRatio;
                break;
            case MagicType.Offensive:
                offensiveFill.fillAmount = fillRatio;
                break;
            case MagicType.Defensive:
                defensiveFill.fillAmount = fillRatio;
                break;
            case MagicType.Ultimate:
                ultimateFill.fillAmount = fillRatio;
                break;
        }
    }
    
    public void UpdateCooldownSprite(MagicType type, Sprite newSprite)
    {
        switch (type)
        {
            case MagicType.Basic:
                basicSprite.sprite = newSprite;
                break;
            case MagicType.Offensive:
                offensiveSprite.sprite = newSprite;
                break;
            case MagicType.Defensive:
                defensiveSprite.sprite = newSprite;
                break;
            case MagicType.Ultimate:
                ultimateSprite.sprite = newSprite;
                break;
        }
    }
}
