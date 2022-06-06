using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static Shield Instance;
    public MagicData myMagic;
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        Instance = this;
        StartCoroutine(DisableAfterXSeconds());
    }

    public void DestroyShield()
    {
        Instance = null;
        gameObject.SetActive(false);
    }

    public IEnumerator DisableAfterXSeconds()
    {
        yield return new WaitForSeconds(myMagic.duration);
        gameObject.SetActive(false);
    }
}
