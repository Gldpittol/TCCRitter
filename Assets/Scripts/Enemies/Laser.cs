using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float increaseSpeed;
    public float damage;
    public float delayBetweenPlayerHits = 0.5f;

    private bool canIncrease= true;
    private bool isTouchingPlayer = false;
    private float currentTime;

    private void OnEnable()
    {
        transform.localScale = new Vector2(0, transform.localScale.y);
        isTouchingPlayer = false;
        currentTime = 0;
        canIncrease = true;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (isTouchingPlayer && currentTime < 0)
        {
            PlayerCollision.Instance.PlayerTakeDamage(damage);
            currentTime = delayBetweenPlayerHits;
        }
    }

    private void FixedUpdate()
    {
        if (!canIncrease) return;
        transform.localScale = new Vector2(transform.localScale.x + increaseSpeed, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            canIncrease = false;
        }

        if (col.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
