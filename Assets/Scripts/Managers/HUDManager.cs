using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private GameObject hpBar;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject rouletteMenu;
    [SerializeField] private TextMeshProUGUI coinsHUD;
    [SerializeField] private TextMeshProUGUI coinsRoulette;
    [SerializeField] private Image basicFill;
    [SerializeField] private Image offensiveFill;
    [SerializeField] private Image defensiveFill;
    [SerializeField] private Image ultimateFill;
    [SerializeField] private Image basicSprite;
    [SerializeField] private Image offensiveSprite;
    [SerializeField] private Image defensiveSprite;
    [SerializeField] private Image ultimateSprite;
    [SerializeField] private Image rouletteBasicSprite;
    [SerializeField] private Image rouletteOffensiveSprite;
    [SerializeField] private Image rouletteDefensiveSprite;
    [SerializeField] private Image rouletteUltimateSprite;
    [SerializeField] private TextMeshProUGUI basicTooltip;
    [SerializeField] private TextMeshProUGUI offensiveTooltip;
    [SerializeField] private TextMeshProUGUI defensiveTooltip;
    [SerializeField] private TextMeshProUGUI ultimateTooltip;
    public TextMeshProUGUI ultimateBlockText;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1;

    private float hpBarOriginalScaleX;

    public Image FadeImage => fadeImage;
    public float FadeTime => fadeTime;

    private void Awake()
    {
        hpBarOriginalScaleX = hpBar.transform.localScale.x;
        Instance = this;
        UpdateHealthBar();
        UpdateCoins();
    }

    private void Start()
    {
        PlayerSpellCasting.Instance.UpdateSpells();
        PlayerMovement.Instance.ChangeFKeyVisibility(false);
        GameManager.Instance.FadeOut(fadeImage,fadeTime);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if(gameOverPanel.activeInHierarchy)
        {
            return;
        }

        if (fadeImage.enabled)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (rouletteMenu.activeInHierarchy) return;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (pauseMenu.activeInHierarchy) return;
            rouletteMenu.SetActive(!rouletteMenu.activeInHierarchy);
            if (rouletteMenu.activeInHierarchy)
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
                rouletteBasicSprite.sprite = newSprite;
                break;
            case MagicType.Offensive:
                offensiveSprite.sprite = newSprite;
                rouletteOffensiveSprite.sprite = newSprite;
                break;
            case MagicType.Defensive:
                defensiveSprite.sprite = newSprite;
                rouletteDefensiveSprite.sprite = newSprite;
                break;
            case MagicType.Ultimate:
                ultimateSprite.sprite = newSprite;
                rouletteUltimateSprite.sprite = newSprite;
                break;
        }
    }
    public void UpdateTooltips(MagicType type, string newText)
    {
        switch (type)
        {
            case MagicType.Basic:
                basicTooltip.text = newText;
                break;
            case MagicType.Offensive:
                offensiveTooltip.text = newText;
                break;
            case MagicType.Defensive:
                defensiveTooltip.text = newText;
                break;
            case MagicType.Ultimate:
                ultimateTooltip.text = newText;
                break;
        }
    }

    public void UpdateCoins()
    {
        coinsHUD.text = PlayerStats.coins.ToString("F0");
        coinsRoulette.text = PlayerStats.coins.ToString("F0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameManager.Instance.gameState = GameState.Paused;
        gameOverPanel.SetActive(true);
    }
}
