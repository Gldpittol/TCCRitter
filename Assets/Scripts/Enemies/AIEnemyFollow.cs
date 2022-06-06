using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIEnemyFollow : MonoBehaviour
{
    public bool canMove = true;

    public float currentDelayBetweenHits = 0;

    public bool isDamagingPlayer = false;

    private EnemyController _enemyController;
    private Animator _animator;

    private NavMeshAgent _navAgent;

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
        if(canMove)transform.position = Vector2.MoveTowards(transform.position, PlayerManager.Instance.gameObject.transform.position, _enemyController.speed * Time.deltaTime);
        float scaleX = Mathf.Abs(transform.localScale.x);
        if (PlayerManager.Instance.transform.position.x < transform.position.x) scaleX = -scaleX;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);

        if (isDamagingPlayer) currentDelayBetweenHits += Time.deltaTime;

        if (currentDelayBetweenHits > _enemyController.delayBetweenAttacks)
        {
            PlayerCollision.Instance.PlayerTakeDamage(_enemyController.baseDamage);
            currentDelayBetweenHits = 0;
        }

        if (canMove)
        {
            _animator.speed = 1f;
        }
        else
        {
            _animator.speed = 0.5f;
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
