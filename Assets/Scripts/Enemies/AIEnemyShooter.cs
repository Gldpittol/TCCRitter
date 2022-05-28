using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyShooter : MonoBehaviour
{
    private EnemyController myController;
    private SpriteRenderer sr;
    
    [SerializeField] private float timeOnShootSprite;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite shootSprite;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform shootSpawnPosition;

    private void Awake()
    {
        myController = GetComponent<EnemyController>();
        sr = GetComponent<SpriteRenderer>();
        Shoot();
    }

    private void Update()
    {
        float scaleX = Mathf.Abs(transform.localScale.x);
        if (PlayerManager.Instance.transform.position.x < transform.position.x) scaleX = -scaleX;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);
    }

    public void Shoot()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(myController.delayBetweenAttacks - timeOnShootSprite);
        sr.sprite = shootSprite;
        GameObject tempShoot = Instantiate(shootPrefab, shootSpawnPosition.position, Quaternion.identity);
        Vector2 shootDirection = (PlayerManager.Instance.transform.position - shootSpawnPosition.position);
        shootDirection = shootDirection.normalized;

        tempShoot.GetComponent<Rigidbody2D>().velocity =
            shootDirection * myController.projectileSpeed;
        tempShoot.GetComponent<EnemyShooterBullet>().damage = myController.baseDamage;
        yield return new WaitForSeconds(timeOnShootSprite);
        sr.sprite = idleSprite;
        Shoot();
    }
}
