using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float timeBeforeAutoExplosion;
    private bool hitPlayer = false;
    public float damage;
    public CircleCollider2D BigCollider;
    public CircleCollider2D SmallCollider;

    private float currentTime;
    private bool isExploding;
    private bool playerTouched = false;

    private void Update()
    {
        if (isExploding) return;
        
        currentTime += Time.deltaTime;
        if (currentTime > timeBeforeAutoExplosion)
        {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerTouched = true;
            Explode();
        }
    }

    public void DamagePlayer()
    {
        if (playerTouched)
        {
            PlayerCollision.Instance.PlayerTakeDamage(damage);
        }
    }

    public void Explode()
    {
        if (isExploding) return;
        isExploding = true;
        StartCoroutine(ExplodeCoroutine());
    }
    
    public IEnumerator ExplodeCoroutine()
    {
        SmallCollider.enabled = false;
        BigCollider.enabled = true;
        GetComponent<Animator>().Play("BombExploding");
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        DamagePlayer();
    }

    public void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
