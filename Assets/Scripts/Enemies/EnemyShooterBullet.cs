using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterBullet : MonoBehaviour
{
    private bool hit = false;
    public float damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hit) return;
        if (col.CompareTag("Player"))
        {
            hit = true;
            col.GetComponent<PlayerCollision>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
