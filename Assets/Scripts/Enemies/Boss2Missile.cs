using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Missile : MonoBehaviour
{
    private bool hit = false;
    public float damage;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hit) return;
        if (col.CompareTag("Player"))
        {
            hit = true;
            col.GetComponent<PlayerCollision>().PlayerTakeDamage(damage);
            animator.Play("Boss2MissileExplosion");
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if (col.CompareTag("Wall"))
        {
            animator.Play("Boss2MissileExplosion");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
