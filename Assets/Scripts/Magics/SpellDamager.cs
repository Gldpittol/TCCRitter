using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamager : MonoBehaviour
{
    public float damage;
    
    private void DestroySpell()
    {
        Destroy(gameObject);
    }
}
