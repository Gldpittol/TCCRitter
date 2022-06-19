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
    [SerializeField] private Image dashFill;
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
    [SerializeField] private List<RectTransform> warningIconList = new List<RectTransform>();
    [SerializeField] private List<GameObject> warningPositionReferences = new List<GameObject>();
    [SerializeField] private GameObject warningIconPrefab;
    [SerializeField] private GameObject warningPanel;

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
        if(!SaveLoadManager.Instance) PlayerSpellCasting.Instance.UpdateSpells();
        PlayerMovement.Instance.ChangeFKeyVisibility(false);
        GameManager.Instance.FadeOut(fadeImage,fadeTime);
    }

    private void Update()
    {
        UpdateWarningIcons();
        
        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }*/
        
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
                CameraManager.Instance.FinishLerp();
                if(!PlayerMovement.Instance.beingPushed) PlayerMovement.Instance.ActivatePause();
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

    public void UpdateDashCooldownFill(float current, float max)
    {
        float fillRatio = current / max;
        dashFill.fillAmount = fillRatio;

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
        if (SaveLoadManager.Instance)
        {
            PlayerStats.coins = SaveLoadManager.PlayerData.gold;
        }
        coinsHUD.text = PlayerStats.coins.ToString("F0");
        coinsRoulette.text = PlayerStats.coins.ToString("F0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameManager.Instance.gameState = GameState.Paused;
        gameOverPanel.SetActive(true);
    }

    public void OpenGachaPanel()
    {
        if (pauseMenu.activeInHierarchy) return;
            rouletteMenu.SetActive(!rouletteMenu.activeInHierarchy);
            if (rouletteMenu.activeInHierarchy)
            {
                Time.timeScale = 0;
                GameManager.Instance.gameState = GameState.Paused;
                PlayerMovement.Instance.ActivatePause();
                CameraManager.Instance.FinishLerp();
            }
            else 
            {
                Time.timeScale = 1;
                PlayerSpellCasting.Instance.ResetCooldowns();
                GameManager.Instance.gameState = GameState.Gameplay;
            }
    }

    public void AddToInteractionIcons(GameObject positionToSpawn)
    {
        GameObject warning = Instantiate(warningIconPrefab, positionToSpawn.transform.position, Quaternion.identity, warningPanel.transform);
        
        warningIconList.Add(warning.GetComponent<RectTransform>());
        warningPositionReferences.Add(positionToSpawn);
    }

    private float width;
    private float height;
    private void UpdateWarningIcons()
    {
        foreach (RectTransform rect in warningIconList)
        {
            rect.gameObject.transform.position = warningPositionReferences[warningIconList.IndexOf(rect)].transform.position;

            if(height == 0) width = GetComponent<CanvasScaler>().referenceResolution.x; 
            if(height == 0) height = GetComponent<CanvasScaler>().referenceResolution.y; 

            float iconX = Mathf.Clamp(rect.anchoredPosition.x, -width / 2 + rect.sizeDelta.x/2, width / 2 - rect.sizeDelta.x/2);
            float iconY = Mathf.Clamp(rect.anchoredPosition.y, -height / 2 + rect.sizeDelta.y/2, height / 2 - rect.sizeDelta.y/2);
            rect.anchoredPosition = new Vector2(iconX, iconY);
        }
    }

}
