using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellCasting : MonoBehaviour
{
    public MagicData magicRightClick;
    public float cooldownRightClick;
    private void Update()
    {
        ReduceCooldowns();
        
        if (Input.GetButton("Fire1"))
        {
            if (cooldownRightClick > 0) return;
            ShootFireball();
        }
    }

    public void ReduceCooldowns()
    {
        cooldownRightClick -= Time.deltaTime;
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
        
        //spellsActive.Add(temp);
    }
}
