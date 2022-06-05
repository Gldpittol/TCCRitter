using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrosphere : MonoBehaviour
{
    public SpellDamager damager;
    private bool hit = false;
    private int health = 3;
    private void Awake()
    {
        damager = GetComponent<SpellDamager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (hit) return;
            hit = true;
            col.GetComponent<EnemyController>().TakeDamage(damager.damage);
            Destroy(gameObject);
        }

        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
