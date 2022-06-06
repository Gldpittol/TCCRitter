using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FireBoulder : MonoBehaviour
{
    public AudioClip spawnClip;
    private List<GameObject> damagedEnemyList = new List<GameObject>();
    public MagicData myMagic;


    public void Initialize()
    {
        transform.parent.transform.parent = null;

    }

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + myMagic.baseSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (damagedEnemyList.Contains(col.gameObject)) return;
            damagedEnemyList.Add(col.gameObject);
            var enemy = col.GetComponent<EnemyController>();
            enemy.TakeDamage(GetComponent<SpellDamager>().damage);
        }
        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
