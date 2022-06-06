using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIEnemyBomb : MonoBehaviour
{
    private EnemyController _enemyController;
    private Animator _animator;
    private bool isExploding = false;
    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemyController.speed = Random.Range(_enemyController.speed - 0.2f, _enemyController.speed + 0.2f);
    }

    private void Update()
    {
        if (isExploding) return;
        
        transform.position = Vector2.MoveTowards(transform.position, PlayerManager.Instance.gameObject.transform.position, 
            _enemyController.speed * Time.deltaTime);
        float scaleX = Mathf.Abs(transform.localScale.x);
        if (PlayerManager.Instance.transform.position.x < transform.position.x) scaleX = -scaleX;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExploding) return;
        if(collision.CompareTag("Player"))
        {
            isExploding = true;
            _animator.Play("EnemyBombExplosion");
            collision.GetComponent<PlayerCollision>().PlayerTakeDamage(_enemyController.baseDamage);
        }
    }
    

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
