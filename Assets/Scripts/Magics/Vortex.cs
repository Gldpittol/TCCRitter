using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Vortex : MonoBehaviour
{
    public List<Rigidbody2D> collidedEnemyList = new List<Rigidbody2D>();
    public List<EnemyController> collidedEnemyControllerList = new List<EnemyController>();

    public float suctionForce;
    public float distanceToDamage;
    public float distanceToStopSucking = 0.5f;
    public float slowedMagnitude = 0.5f;

    public MagicData myMagic;
    private SpellDamager damager;

    private float currentTime;

    private void Awake()
    {
        damager = GetComponent<SpellDamager>();
        Destroy(gameObject, myMagic.duration);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Bullet"))
        {
            Rigidbody2D colRb = col.gameObject.GetComponent<Rigidbody2D>();
            if (!collidedEnemyList.Contains(colRb))
            {
                collidedEnemyList.Add(colRb);
                collidedEnemyControllerList.Add(colRb.GetComponent<EnemyController>());
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Bullet"))
        {
            Rigidbody2D colRb = col.gameObject.GetComponent<Rigidbody2D>();
            if (collidedEnemyList.Contains(colRb))
            {
                collidedEnemyList.Remove(colRb);
                collidedEnemyControllerList.Remove(colRb.GetComponent<EnemyController>());
            }
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > myMagic.delayBetweenHits)
        {
            currentTime = 0;
            for (int i = 0; i < collidedEnemyList.Count; i++)
            {
                if (collidedEnemyList[i])
                {
                    if (Vector2.Distance(collidedEnemyList[i].transform.position, transform.position) < distanceToDamage)
                    {
                        if(collidedEnemyControllerList[i]) collidedEnemyControllerList[i].TakeDamage(damager.damage);
                    }
                }
            }
        }
        
        
    }


    private void FixedUpdate()
    {
        for (int i = 0; i < collidedEnemyList.Count; i++)
        {
            if (collidedEnemyList[i])
            {
                if (Vector2.Distance(transform.position, collidedEnemyList[i].transform.position) <
                    distanceToStopSucking)
                {
                    collidedEnemyList[i].velocity = collidedEnemyList[i].velocity.normalized * slowedMagnitude;
                    continue;
                }
                var force = collidedEnemyList[i].transform.position - transform.position;
                collidedEnemyList[i].AddForce(-force * suctionForce);
            }
        }
    }
}
