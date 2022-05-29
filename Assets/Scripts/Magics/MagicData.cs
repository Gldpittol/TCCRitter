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
   [TextArea(3,3)]
   public string magicDescription;
   public MagicType magicType;
   public GameObject magicPrefab;
   public Sprite magicIcon;
   public float cooldown;
   public float baseSpeed;
   public float baseDamage;
   public float duration;
   public float delayBetweenHits = 0.1f;
}
