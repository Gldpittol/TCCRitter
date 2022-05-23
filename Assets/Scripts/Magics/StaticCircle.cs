using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCircle : MonoBehaviour
{
    public MagicData myMagic;
    
    private List<EnemyController> enemiesCollidingList = new List<EnemyController>();
    private SpellDamager damager;
    private float currentTime = 0f;
    private void Awake()
    {
        damager = GetComponent<SpellDamager>();
        Destroy(gameObject, myMagic.duration);
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime > 0) return;
        
        for (int i = 0; i < enemiesCollidingList.Count; i++)
        {
            print("damaging");
            enemiesCollidingList[i].TakeDamage(damager.damage);
        }
        currentTime = myMagic.delayBetweenHits;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (enemiesCollidingList.Contains(col.GetComponent<EnemyController>())) return;
            
            enemiesCollidingList.Add(col.GetComponent<EnemyController>());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (!enemiesCollidingList.Contains(col.GetComponent<EnemyController>())) return;
            
            enemiesCollidingList.Remove(col.GetComponent<EnemyController>());
        }
    }
}
