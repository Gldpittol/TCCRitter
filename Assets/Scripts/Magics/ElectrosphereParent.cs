using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ElectrosphereParent : MonoBehaviour
{
    public float angularSpeed = 10;
    public MagicData myMagic;
    public Vector3 offset;
    public Electrosphere[] electrospheres;
    public float damage;
    public void Initialize()
    {
        Destroy(gameObject, myMagic.duration);
        foreach (Electrosphere el in electrospheres)
        {
            el.damager.damage = damage;
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,angularSpeed * Time.deltaTime));
        transform.position = PlayerManager.Instance.transform.position + offset;
    }
}
