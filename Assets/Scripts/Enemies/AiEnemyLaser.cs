using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemyLaser : MonoBehaviour
{
    public GameObject laser;
    private EnemyController myController;
    private bool isLaserOnField;

    private void Awake()
    {
        myController = GetComponent<EnemyController>();
        laser.GetComponent<Laser>().damage = myController.baseDamage;
        SpawnLaser();
    }

    private void Update()
    {
        if (isLaserOnField) return;
        float scaleX = Mathf.Abs(transform.localScale.x);
        if (PlayerManager.Instance.transform.position.x < transform.position.x) scaleX = -scaleX;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);
    }

    public void SpawnLaser()
    {
        StartCoroutine(SpawnLaserCoroutine());
    }

    public IEnumerator SpawnLaserCoroutine()
    {
        yield return new WaitForSeconds(myController.delayBetweenAttacks);
        laser.SetActive(true);
        isLaserOnField = true;
        yield return new WaitForSeconds(myController.projectileDuration);
        laser.SetActive(false);
        isLaserOnField = false;
        SpawnLaser();
    }
}
