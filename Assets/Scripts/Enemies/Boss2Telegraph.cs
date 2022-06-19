using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Boss2Telegraph : MonoBehaviour
{
    private bool isDone = false;
    private float lerpToPlayerIntensity;
    public float YOffset;

    private void Update()
    {
        if (isDone) return;

        Vector2 lerpDestination = new Vector2(0, PlayerManager.Instance.transform.position.y + YOffset);
        transform.position = Vector3.Lerp(transform.position, lerpDestination,
            lerpToPlayerIntensity);
    }

    public void DelayedFireSpawn(float lerpIntensity, float delayBeforeFire, float timeFireOnField, float fireDamage, float delayBetweenFireHits)
    {
        lerpToPlayerIntensity = lerpIntensity;
        StartCoroutine(DelayedFireSpawnCoroutine(delayBeforeFire, timeFireOnField, fireDamage,
            delayBetweenFireHits));
    }

    public IEnumerator DelayedFireSpawnCoroutine(float delayBeforeFire, float timeFireOnField, float fireDamage, float delayBetweenFireHits)
    {
        yield return new WaitForSeconds(delayBeforeFire);
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<Boss2LongFire>().SetParameters(timeFireOnField, fireDamage, delayBetweenFireHits);
        isDone = true;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
