using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Fireball : MonoBehaviour
{
    public AudioClip spawnClip;
    private bool damagedEnemy = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (damagedEnemy) return;
        if (col.CompareTag("Enemy"))
        {
            damagedEnemy = true;
            var enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(GetComponent<SpellDamager>().damage);
            Destroy(gameObject);
        }
        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
