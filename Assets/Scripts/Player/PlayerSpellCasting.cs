using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellCasting : MonoBehaviour
{
    public static PlayerSpellCasting Instance;
    public MagicData magicRightClick;
    public MagicData magicOffensive;
    public MagicData magicDefensive;
    public MagicData magicUltimate;

    public float cooldownRightClick;
    public float cooldownOffsensive;
    public float cooldownDefensive;
    public float cooldownUltimate;

    public event Action onClickBaseMagic;
    public event Action onClickOffensiveMagic;
    public event Action onClickDefensiveMagic;
    public event Action onClickUltimateMagic;


    [SerializeField] private Animator staffAnimator;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int basicMagicID = MagicManager.Instance.basicMagicsList.IndexOf(magicRightClick);
        int offensiveMagicID = MagicManager.Instance.offensiveMagicsList.IndexOf(magicOffensive);
        int defensiveMagicID = MagicManager.Instance.defensiveMagicsList.IndexOf(magicDefensive);
        int ultimateMagicID = MagicManager.Instance.ultimateMagicsList.IndexOf(magicUltimate);
        SelectBaseMagic(basicMagicID);
        SelectOffensiveMagic(offensiveMagicID);
        SelectDefensiveMagic(defensiveMagicID);
        SelectUltimateMagic(ultimateMagicID);
    }

    private void Update()
    {
        ReduceCooldowns();
        
        if (Input.GetButton("Fire1"))
        {
            if (cooldownRightClick > 0) return;
            onClickBaseMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
        if (Input.GetButton("Fire2"))
        {
            if (cooldownDefensive > 0) return;
            onClickDefensiveMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cooldownOffsensive > 0) return;
            onClickOffensiveMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
    }

    public void ReduceCooldowns()
    {
        cooldownRightClick -= Time.deltaTime;
        cooldownOffsensive -= Time.deltaTime;
        cooldownDefensive -= Time.deltaTime;
        cooldownUltimate -= Time.deltaTime;
    }

    public void SelectBaseMagic(int ID)
    {
        onClickBaseMagic = null;

        switch (ID)
        {
            case 0:
                onClickBaseMagic += CastFireball;
                break;
            case 1:
                onClickBaseMagic += CastWaterBubble;
                break;
        }
    }

    public void SelectOffensiveMagic(int ID)
    {
        onClickOffensiveMagic = null;

        switch (ID)
        {
            case 0:
                onClickOffensiveMagic += CastStaticField;
                break;
        }
    }
    public void SelectDefensiveMagic(int ID)
    {
        onClickDefensiveMagic = null;

        switch (ID)
        {
            case 0:
                onClickDefensiveMagic += CastWindWall;
                break;
        }
    }

    public void SelectUltimateMagic(int ID)
    {
        onClickUltimateMagic = null;

        switch (ID)
        {
            case 0:
                onClickUltimateMagic += CastStaticField;
                break;
        }
    }
    
    private void CastWindWall()
    {
        cooldownDefensive = magicDefensive.cooldown;
        Instantiate(magicDefensive.magicPrefab, transform.position, Quaternion.identity);
    }

    private void CastStaticField()
    {
        cooldownOffsensive = magicOffensive.cooldown;
        GameObject temp = Instantiate(magicOffensive.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.GetComponent<SpellDamager>().damage = magicOffensive.baseDamage * PlayerStats.damageMultiplier;
    }

    public void CastFireball()
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
    
    public void CastWaterBubble()
    {
        cooldownRightClick = magicRightClick.cooldown;
        GameObject temp = Instantiate(magicRightClick.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.GetComponent<SpellDamager>().damage = magicRightClick.baseDamage * PlayerStats.damageMultiplier;
    }
}
