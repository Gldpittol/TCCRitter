using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float baseDamage;
    public float health;
    public float speed;
    public float delayBetweenAttacks;
    public float projectileSpeed;
    public float projectileDuration;
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        StartCoroutine(ChangeColor());

        if(health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(this.gameObject);
    }

    public IEnumerator ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = PlayerCollision.Instance.hitColor;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
