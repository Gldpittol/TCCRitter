using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    [SerializeField]private float damage;
    private bool hit;
    [SerializeField]private float duration;

    public void Initialize(float _damage, float _duration)
    {
        damage = _damage;
        duration = _duration;
        Destroy(gameObject, duration);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hit) return;
        if (damage == 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            return;
        }
        if (col.CompareTag("Player"))
        {
            hit = true;
            PlayerCollision.Instance.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
