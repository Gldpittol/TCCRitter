using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMissile : MonoBehaviour
{
    private bool collided = false;
    private bool canDamage = false;
    public CircleCollider2D circleCol;
    public BoxCollider2D boxCol;
    private List<GameObject> enemiesToDamageList = new List<GameObject>();
    private GameObject mainObject;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (!canDamage)
            {
                if (collided) return;
                collided = true;
                enemiesToDamageList.Add(col.gameObject);
                mainObject = col.gameObject;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                EnableDamage();
            }

            if (canDamage)
            {
                if (enemiesToDamageList.Contains(col.gameObject)) return;
                enemiesToDamageList.Add(col.gameObject);
            }
        }

        if (col.CompareTag("Wall"))
        {
            if (!canDamage)
            {
                if (collided) return;
                collided = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                EnableDamage();
            }
        }
    }

    public void EnableDamage()
    {
        StartCoroutine(DamageAllEnemiesAround());
    }

    public void DamageEnemies()
    {
        for (int i = 0; i < enemiesToDamageList.Count; i++)
        {
            enemiesToDamageList[i].GetComponent<EnemyController>().TakeDamage(GetComponent<SpellDamager>().damage);
            if (mainObject == enemiesToDamageList[i])
            {
                enemiesToDamageList[i].GetComponent<EnemyController>().TakeDamage(GetComponent<SpellDamager>().damage);
            }
        }
    }

    public IEnumerator DamageAllEnemiesAround()
    {
        circleCol.enabled = true;
        boxCol.enabled = false;
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        canDamage = true;
        GetComponent<Animator>().Play("IceMissileExplosion");
    }
    
}
