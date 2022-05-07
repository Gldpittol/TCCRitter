using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellCasting : MonoBehaviour
{
    public static PlayerSpellCasting Instance;
    public MagicData magicRightClick;
    public float cooldownRightClick;

    public int magicID;

    public event Action onClickBaseMagic;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int basicMagicID = MagicManager.Instance.basicMagicsList.IndexOf(magicRightClick);
        SelectBaseMagic(basicMagicID);
    }

    private void Update()
    {
        ReduceCooldowns();
        
        if (Input.GetButton("Fire1"))
        {
            if (cooldownRightClick > 0) return;
            onClickBaseMagic?.Invoke();
        }
    }

    public void ReduceCooldowns()
    {
        cooldownRightClick -= Time.deltaTime;
    }

    public void SelectBaseMagic(int ID)
    {
        onClickBaseMagic = null;

        switch (ID)
        {
            case 0:
                onClickBaseMagic += ShootFireball;
                break;
            case 1:
                onClickBaseMagic += SpawnWaterBubble;
                break;
        }
    }
    
    public void ShootFireball()
    {
        cooldownRightClick = magicRightClick.cooldown;
        GameObject temp = Instantiate(magicRightClick.magicPrefab, PlayerManager.Instance.spellSpawnPoint.transform.position, Quaternion.identity);

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - PlayerManager.Instance.spellSpawnPoint.transform.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * magicRightClick.baseSpeed;

        temp.GetComponent<SpellDamager>().damage = magicRightClick.baseDamage * PlayerStats.damageMultiplier;
    }
    
    public void SpawnWaterBubble()
    {
        cooldownRightClick = magicRightClick.cooldown;
        GameObject temp = Instantiate(magicRightClick.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.GetComponent<SpellDamager>().damage = magicRightClick.baseDamage * PlayerStats.damageMultiplier;
    }
}
