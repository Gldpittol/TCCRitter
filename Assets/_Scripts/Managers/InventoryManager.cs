using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
   
    [SerializeField] private GachaManager _gachaManager;
    [SerializeField] private List<MagicData> _availableMagics;
    public void UpdateAvailableSpells()
    {
        _availableMagics.Clear();
        foreach (int id in SaveLoadManager.PlayerData.magicsObtained)
        {
            _availableMagics.Add(_gachaManager.MagicsList[id]);
        }
        foreach (int id in SaveLoadManager.PlayerData.ultimatesObtained)
        {
            _availableMagics.Add(_gachaManager.UltimatesList[id]);
        }
    }
}
