using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubble : MonoBehaviour
{
    public AudioClip explodeClip;
    private List<GameObject> damagedEnemiesList = new List<GameObject>();
    [SerializeField] private MagicData magic;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (damagedEnemiesList.Contains(col.gameObject)) return;
            
            damagedEnemiesList.Add(col.gameObject);
           
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (!damagedEnemiesList.Contains(col.gameObject)) return;
            damagedEnemiesList.Remove(col.gameObject);
        }
    }

    private void DealDamage()
    {
        for (int i = 0; i < damagedEnemiesList.Count; i++)
        {
            damagedEnemiesList[i].GetComponent<EnemyController>().TakeDamage(GetComponent<SpellDamager>().damage);

        }
    }

    private void DestroyBubble()
    {
        Destroy(gameObject);
    }
}
