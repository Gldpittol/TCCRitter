using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GachaManager : MonoBehaviour
{
    public static GachaManager Instance;
    [SerializeField] private float _ultimatePullRate = 0.01f;
    [SerializeField] private Text _dropText;
    [SerializeField] InventoryManager _inventory;

    [SerializeField] private List<MagicData> _magicsList = new List<MagicData>();
    public List<MagicData> MagicsList => _magicsList;
    [SerializeField] private List<MagicData> _ultimatesList = new List<MagicData>();
    public List<MagicData> UltimatesList => _ultimatesList;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) PullOnce();
    }

    private void Start()
    {
        _inventory.UpdateAvailableSpells();
    }

    public void PullOnce()
    {
        bool gotUltimate = Random.value < _ultimatePullRate;
        MagicData magicObtained;
        if (gotUltimate)
        {
            int rnd = Random.Range(0, _ultimatesList.Count);
            magicObtained = _ultimatesList[rnd];
            _dropText.color = Color.yellow;
            
            if (!SaveLoadManager.PlayerData.ultimatesObtained.Contains(rnd))
            {
                SaveLoadManager.PlayerData.ultimatesObtained.Add(rnd);
                _dropText.text = "You've Obtained: " + magicObtained.magicName + "!";
            }
            else
            {
                _dropText.text = "You've Already Obtained: " + magicObtained.magicName + "! Discarding!";
            }
        }
        else
        {
            int rnd = Random.Range(0, _magicsList.Count);
            magicObtained = _magicsList[rnd];
            _dropText.color = Color.white;
            
            if (!SaveLoadManager.PlayerData.magicsObtained.Contains(rnd))
            {
                SaveLoadManager.PlayerData.magicsObtained.Add(rnd);
                _dropText.text = "You've Obtained: " + magicObtained.magicName + "!";
            }
            else
            {
                _dropText.text = "You've Already Obtained: " + magicObtained.magicName + "! Discarding!";
            }
        }
        
        SaveLoadManager.PlayerData.ultimatesObtained.Sort();
        SaveLoadManager.PlayerData.magicsObtained.Sort();
        _inventory.UpdateAvailableSpells();
    }
}
