using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class IceSpikesParent : MonoBehaviour
{
    public float delayBetweenShooting = 0.3f;
    public IceSpikes[] spikes;
    public GameObject[] spikesParents;
    public MagicData myMagic;
    public float damage;
    public Vector3 offset;
    private int currentID;
    [FormerlySerializedAs("maxID")] public int amountOfSpikes;
    private void Update()
    {
        transform.position = PlayerManager.Instance.transform.position + offset;
    }

    public void Initialize()
    {
        foreach (IceSpikes sp in spikes)
        {
            sp.damager.damage = damage;
            sp.speed = myMagic.baseSpeed;
        }
        foreach (GameObject par in spikesParents)
        {
            Destroy(par, myMagic.duration);
        }
        Destroy(gameObject, myMagic.duration);
        StartCoroutine(PerformClockShoot());
    }

    public IEnumerator PerformClockShoot()
    {
        while (currentID < amountOfSpikes)
        {
            yield return new WaitForSeconds(delayBetweenShooting);
            if (spikes[currentID])
            {
                spikes[currentID].canMove = true;
                spikes[currentID].transform.parent.transform.parent = null;
            }
            currentID++;
        }
        
    }
}
