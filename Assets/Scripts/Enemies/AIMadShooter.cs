using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMadShooter : MonoBehaviour
{
    private EnemyController myController;
    private SpriteRenderer sr;
    private float lastShootX;
    
    [SerializeField] private GameObject shootPrefab;

    private void Awake()
    {
        myController = GetComponent<EnemyController>();
        sr = GetComponent<SpriteRenderer>();
        Shoot();
    }

    private void Update()
    {
        float scaleX = Mathf.Abs(transform.localScale.x);
        if (lastShootX < 0) scaleX = -scaleX;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);
    }

    public void Shoot()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(myController.delayBetweenAttacks);
        GameObject tempShoot = Instantiate(shootPrefab, transform.position, Quaternion.identity);
        Vector2 shootDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        lastShootX = shootDirection.x;
        tempShoot.GetComponent<Rigidbody2D>().velocity =
            shootDirection * myController.projectileSpeed;
        tempShoot.GetComponent<EnemyShooterBullet>().damage = myController.baseDamage;
        Shoot();
    }
}
