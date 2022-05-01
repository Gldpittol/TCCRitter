using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Fireball : MonoBehaviour
{
    [FormerlySerializedAs("audClip")] public AudioClip spawnClip;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
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
