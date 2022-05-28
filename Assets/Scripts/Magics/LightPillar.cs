using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LightPillar : MonoBehaviour
{
    public MagicData myMagic;
    
    private List<EnemyController> enemiesCollidingList = new List<EnemyController>();
    private SpellDamager damager;
    private float currentTime = 0f;
    private float totalTime;
    private bool isEnding = false;
    private void Awake()
    {
        damager = GetComponent<SpellDamager>();
    }

    private void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime > myMagic.duration && !isEnding)
        {
            isEnding = true;
            EndSpell();
        }
        currentTime -= Time.deltaTime;
        if (currentTime > 0) return;
        
        for (int i = 0; i < enemiesCollidingList.Count; i++)
        {
            enemiesCollidingList[i].TakeDamage(damager.damage);
        }
        currentTime = myMagic.delayBetweenHits;
    }

    private void EndSpell()
    {
        GetComponent<Animator>().Play("LightPillarEnd");
    }

    private void DestroySpell()
    {
        Destroy(gameObject);
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
