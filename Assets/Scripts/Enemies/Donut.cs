using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public List<PearlParent> pealsList = new List<PearlParent>();
    public float delayBetweenDonuts;
    public GameObject donut1;
    public GameObject donut2;
    public GameObject donut3;
    public GameObject donut4;

    public void Initialize(float delay, float damage, float duration)
    {
        delayBetweenDonuts = delay;
        foreach (PearlParent p in pealsList)
        {
            p.damage = damage;
            p.delay = delay;
            p.duration = duration;
        }
        StartCoroutine(DonutCoroutine());
    }

    public IEnumerator DonutCoroutine()
    {
        donut1.SetActive(true);
        yield return new WaitForSeconds(delayBetweenDonuts);
        donut2.SetActive(true);
        yield return new WaitForSeconds(delayBetweenDonuts); 
        donut3.SetActive(true);
        yield return new WaitForSeconds(delayBetweenDonuts); 
        donut4.SetActive(true);
        yield return new WaitForSeconds(delayBetweenDonuts);
        yield return new WaitForSeconds(delayBetweenDonuts);
        Destroy(gameObject);
    }
}
