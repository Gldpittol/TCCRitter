
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision Instance;

    public float delayBeforeDeath;

    public Color hitColor;

    public AudioClip audClip;

    public float soundCooldown = 1f;
    public float currentSoundCooldown = 1f;

    public GameObject shield;
    private void Awake()
    {
        if (PlayerDontDestroy.Instance && PlayerDontDestroy.Instance.gameObject != transform.parent.gameObject) return;
        Instance = this;
    }

    private void Start()
    {
        HUDManager.Instance.UpdateHealthBar();
    }

    private void Update()
    {
        currentSoundCooldown += Time.deltaTime;
    }

    public void PlayerTakeDamage(float damage)
    {
        if (Shield.Instance)
        {
            Shield.Instance.DestroyShield();
            return;
        }
        
        PlayerStats.currentHealth -= damage;
        StartCoroutine(ChangeColor());
        
        if(currentSoundCooldown > soundCooldown)
        {
            AudioManager.Instance.PlayClip(audClip);
            currentSoundCooldown = 0;
        }

        if (PlayerStats.currentHealth < 0) PlayerStats.currentHealth = 0;
        
        HUDManager.Instance.UpdateHealthBar();
        
        if (PlayerStats.currentHealth < 1)
        {
            StartCoroutine(KillPlayer());
        }
    }

    private IEnumerator KillPlayer()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        //HUDManager.Instance.GameOver();
        PlayerStats.currentFloor = 0;
        PlayerStats.currentHealth = 100;
        PlayerStats.invulnerabilityRemaining = 0;
        PlayerSpellCasting.Instance.RerollAllMagics();
        GameManager.Instance.LoadScene(HUDManager.Instance.FadeImage, HUDManager.Instance.FadeTime,"MagePoliceDepartment");

        yield return null;
    }

    public IEnumerator ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = hitColor;
        yield return new WaitForSeconds(0.1f); 
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}

