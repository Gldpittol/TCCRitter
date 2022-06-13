using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrb : MonoBehaviour
{
    public bool hit = false;
    public float damage = 5f;
    public float timeOnField = 5f;
    public float timeToDodge = 2f;

    private void Awake()
    {
        StartCoroutine(GreenOrbCoroutine());
    }

    private IEnumerator GreenOrbCoroutine()
    {
        yield return new WaitForSeconds(timeToDodge);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        Destroy(transform.GetChild(0).gameObject);
        Destroy(gameObject, timeOnField);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hit) return;
        if (col.CompareTag("Player"))
        {
            hit = true;
            PlayerCollision.Instance.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.CompareTag("InstaDeath"))
        {
            Destroy(gameObject);
        }
    }
}
