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

    private bool isChangingColor = false;
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
        Destroy(gameObject);
    }

    public IEnumerator ChangeColor()
    {
        if(isChangingColor) yield break;

        isChangingColor = true;
        GetComponent<SpriteRenderer>().color = PlayerCollision.Instance.hitColor;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        isChangingColor = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    
    private void OnDestroy()
    {
        EnemySpawnerManager.Instance.RemoveFromRemainingEnemiesList(gameObject);
    }
}
