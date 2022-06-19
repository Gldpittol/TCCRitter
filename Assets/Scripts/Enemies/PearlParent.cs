using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlParent : MonoBehaviour
{
    public float delay;
    public float damage;
    public float duration;

    private void Start()
    {
        StartCoroutine(DelayedPearl());
    }

    IEnumerator DelayedPearl()
    {
        yield return new WaitForSeconds(delay);
        transform.parent.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        Pearl pearl = transform.GetChild(0).GetComponent<Pearl>();
        pearl.Initialize(damage,duration);
    }
}
