using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = System.Numerics.Vector2;

public class IceSpikes : MonoBehaviour
{
    public SpellDamager damager;
    private bool hit = false;
    public float speed;
    public bool canMove = false;
    private void Awake()
    {
        damager = GetComponent<SpellDamager>();
    }

    private void Update()
    {
        if (!canMove) return;
        transform.localPosition = new Vector3(transform.localPosition.x + speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (hit) return;
            hit = true;
            col.GetComponent<EnemyController>().TakeDamage(damager.damage);
            Destroy(gameObject);
        }

        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
