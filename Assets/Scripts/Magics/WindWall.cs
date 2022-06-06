using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWall : MonoBehaviour
{
    [SerializeField] private float impulseIntensity;
    private List<GameObject> affectedObjects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Bullet"))
        {
            if (affectedObjects.Contains(col.gameObject)) return;
            Rigidbody2D colRb = col.GetComponent<Rigidbody2D>();
            if (colRb)
            {
                affectedObjects.Add(col.gameObject);
                Vector2 pushVector = transform.position - col.gameObject.transform.position;
                colRb.AddForce(impulseIntensity * pushVector * -1, ForceMode2D.Impulse);
            }
        }
    }

    public void DestroyWindWall()
    {
        Destroy(gameObject);
    }
}
