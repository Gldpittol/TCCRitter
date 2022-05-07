using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    public static MagicManager Instance;
    
    public List<MagicData> basicMagicsList = new List<MagicData>();
    public List<MagicData> offensiveMagicsList = new List<MagicData>();
    public List<MagicData> defensiveMagicsList = new List<MagicData>();
    public List<MagicData> ultimateMagicsList = new List<MagicData>();

    private void Awake()
    {
        Instance = this;
    }
}
