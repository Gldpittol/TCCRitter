using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PurpleOrb : MonoBehaviour
{
    public bool hit = false;
    public float damage = 5f;

    private void Start()
    {
        AttractorField.Instance.AddToList(gameObject);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) < 0.5f)
        {
            AttractorField.Instance.RemoveFromList(gameObject);
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
            AttractorField.Instance.RemoveFromList(gameObject);
            Destroy(gameObject);
        }

        if (col.CompareTag("InstaDeath"))
        {
            AttractorField.Instance.RemoveFromList(gameObject);
            Destroy(gameObject);
        }
    }
}
