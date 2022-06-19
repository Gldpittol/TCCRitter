using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassExplosion : MonoBehaviour
{
    public AudioClip glassExplosionClip;

    private void Awake()
    {
        if(glassExplosionClip)AudioManager.Instance.PlayFX(glassExplosionClip);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
