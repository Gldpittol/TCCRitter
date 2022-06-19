using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float damage;
    private bool hit;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hit) return;
        if (col.CompareTag("Player"))
        {
            hit = true;
            PlayerCollision.Instance.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
