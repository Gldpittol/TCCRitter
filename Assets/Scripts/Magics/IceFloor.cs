using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public float slowedSpeed = 1f;
    public Dictionary<EnemyController, float> enemyOriginalSpeeds = new Dictionary<EnemyController, float>();
    public MagicData myMagic;
    private void Awake()
    {
        Destroy(gameObject, myMagic.duration);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            if (enemyOriginalSpeeds.ContainsKey(enemy)) return;
            else
            {
                enemyOriginalSpeeds.Add(enemy, enemy.speed);
                enemy.speed = slowedSpeed;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            if (!enemyOriginalSpeeds.ContainsKey(enemy)) return;
            else
            {
                enemy.speed = enemyOriginalSpeeds[enemy];
                enemyOriginalSpeeds.Remove(enemy);
            }
        }
    }
}
