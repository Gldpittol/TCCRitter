using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstadeathSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerCollision.Instance.PlayerTakeDamage(10000f);
        }
    }
}
