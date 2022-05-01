using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicType
{
   Basic,
   Defensive,
   Offensive,
   Ultimate
}

[CreateAssetMenu]
public class MagicData : ScriptableObject
{
   public string magicName;
   public MagicType magicType;
   public GameObject magicPrefab;
   public float cooldown;
   public float baseSpeed;
   public float baseDamage;
}
