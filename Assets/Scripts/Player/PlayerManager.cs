using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public GameObject exclamationMark;
    public GameObject spellSpawnPoint;
    public List<GameObject> interactablesCollisionList;   

    private void Awake()
    {
        if (PlayerDontDestroy.Instance && PlayerDontDestroy.Instance.gameObject != transform.parent.gameObject) return;
        Instance = this;
        if (SaveLoadManager.Instance) PlayerStats.progress = SaveLoadManager.PlayerData.progress;
    }
}
