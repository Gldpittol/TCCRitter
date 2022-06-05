using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoulderParent : MonoBehaviour
{
    public SpellDamager[] fireboulders;

    public void Initialize(float newDamage)
    {
        foreach (SpellDamager damager in fireboulders)
        {
            damager.damage = newDamage;
            damager.gameObject.GetComponent<FireBoulder>().Initialize();
        }
    }
}
