using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Boss2LongFire : MonoBehaviour
{
    private float timeFireOnField;
    private float fireDamage;
    private float delayBetweenFireHits;
    private bool parametersSet = false;
    private Animator animator;
    private float currentDelay;
    private bool isHittingPlayer;
    public bool destroyAfterXSeconds = true;
    private void Update()
    {
        if (!parametersSet) return;

        currentDelay -= Time.deltaTime;

        if (isHittingPlayer && currentDelay < 0)
        {
            currentDelay = delayBetweenFireHits;
            PlayerCollision.Instance.PlayerTakeDamage(fireDamage);
        }
    }

    public void SetParameters(float time, float dmage, float delay)
    {
        animator = GetComponent<Animator>();
        timeFireOnField = time;
        fireDamage = dmage;
        delayBetweenFireHits = delay;
        parametersSet = true;
        if(destroyAfterXSeconds)StartCoroutine(DestroyAfterXSeconds());
    }

    public void SetDelayedParameters(float time, float dmage, float delay)
    {
        StartCoroutine(SetDelayedParametersCoroutine(time, dmage, delay));
    }

    public IEnumerator SetDelayedParametersCoroutine(float timeToWait, float dmage, float delay )
    {
        yield return new WaitForSeconds(timeToWait);
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        animator = GetComponent<Animator>();
        animator.enabled = true;
        fireDamage = dmage;
        delayBetweenFireHits = delay;
        parametersSet = true;
        if(destroyAfterXSeconds)StartCoroutine(DestroyAfterXSeconds());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isHittingPlayer = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isHittingPlayer = false;
        }
    }

    public IEnumerator DestroyAfterXSeconds()
    {
        yield return new WaitForSeconds(timeFireOnField);
        animator.Play("FireBoss2End");
    }
    
    public void DestroyObject()
    {
        if(transform.parent != null) Destroy(transform.parent.gameObject);
        else Destroy(gameObject);
    }
}
