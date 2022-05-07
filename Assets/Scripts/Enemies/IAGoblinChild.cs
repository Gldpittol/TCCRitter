using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IAGoblinChild : MonoBehaviour
{

    public bool canMove = true;

    public float currentDelayBetweenHits = 0;

    public bool isDamagingPlayer = false;

    private EnemyController _enemyController;
    private Animator _animator;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemyController.speed = Random.Range(_enemyController.speed - 0.5f, _enemyController.speed + 0.5f);
    }

    private void Update()
    {
        if(canMove) transform.position = Vector2.MoveTowards(transform.position, PlayerManager.Instance.gameObject.transform.position, _enemyController.speed * Time.deltaTime);
        if (transform.position.x < PlayerManager.Instance.gameObject.transform.position.x) transform.localScale = new Vector2(1, 1);
        else transform.localScale = new Vector2(-1, 1);

        if (isDamagingPlayer) currentDelayBetweenHits += Time.deltaTime;

        if (currentDelayBetweenHits > _enemyController.delayBetweenAttacks)
        {
            PlayerCollision.Instance.PlayerTakeDamage(_enemyController.baseDamage);
            currentDelayBetweenHits = 0;
        }

        if (canMove)
        {
            _animator.Play("GoblinChild");
        }
        else
        {
            _animator.Play("GoblinChildIdle");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            currentDelayBetweenHits += Time.deltaTime;
            canMove = false;
            isDamagingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentDelayBetweenHits = 0; 
            isDamagingPlayer = false;
            canMove = true;
        }
    }
}
