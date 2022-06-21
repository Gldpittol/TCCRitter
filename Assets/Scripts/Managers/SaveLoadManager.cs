using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Resources;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[Serializable]
public enum GameProgress
{
   None,
   Level1Clear,
   Boss1Clear,
   Level2Clear,
   Boss2Clear,
   Level3Clear,
   Boss3Clear
}

[Serializable]
public class SaveData
{
   public float gold;
   public GameProgress progress;
   public int baseMagicID;
   public int offensiveMagicID;
   public int defensiveMagicID;
   public int ultimateMagicID;
   public bool justStarting;
   public SaveData()
   {
      gold = 1000;
      progress = GameProgress.None;
      baseMagicID = 0;
      offensiveMagicID = 0;
      defensiveMagicID = 0;
      ultimateMagicID = 0;
      justStarting = true;
   }
   public SaveData(SaveData data)
   {
      gold = data.gold;
      progress = data.progress;
      baseMagicID = data.baseMagicID;
      offensiveMagicID = data.offensiveMagicID;
      defensiveMagicID = data.defensiveMagicID;
      ultimateMagicID = data.ultimateMagicID;
      justStarting = data.justStarting;
   }
}

public class SaveLoadManager : MonoBehaviour
{
   public static SaveLoadManager Instance;
   public static SaveData PlayerData;

   [SerializeField] private string _jsonPath;

   [SerializeField] private KeyCode _quickSaveKey;
   [SerializeField] private KeyCode _quickLoadKey;
   [SerializeField] private KeyCode _quickDeleteKey;

   [Header("Debug")]
   [SerializeField]
   private bool _debugDataVisualization;
   [SerializeField]
   private bool _debugQuickKeys = true;
   [SerializeField] private SaveData _playerDataVisualization;

   private void Awake()
   {
      if (!Instance)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }   
   }

   private void Start()
   {
      Initialize();
   }

   private void Update()
   {
      if(PlayerData != null && _debugDataVisualization) _playerDataVisualization = PlayerData;
      if (_debugQuickKeys)
      {
         if(Input.GetKey(KeyCode.U))
         {
            if (Input.GetKeyDown(_quickSaveKey))
            {
               SaveGame();
            }
            if (Input.GetKeyDown(_quickLoadKey))
            {
               LoadGame();
            } if (Input.GetKeyDown(_quickDeleteKey))
            {
               DeleteSave();
            }
         }
      }
      if (Input.GetKey(KeyCode.U))
      {
         if (Input.GetKeyDown(KeyCode.A))
         {
            PlayerStats.progress = GameProgress.Level3Clear;
            if (SaveLoadManager.Instance) SaveLoadManager.PlayerData.progress = GameProgress.Level3Clear;
         }
      }
   }

   public void Initialize()
   {
      DontDestroyOnLoad(gameObject);
      _jsonPath = Application.persistentDataPath + _jsonPath;
      CheckIfSaveExists();
   }

   public void CheckIfSaveExists()
   {
      string jsonString = "";
      print(_jsonPath);
     
      if (File.Exists(_jsonPath))
      {
       //  print("Save Found, Game Loaded");
         jsonString = File.ReadAllText(_jsonPath);
         if (string.IsNullOrEmpty(jsonString))
         {
            PlayerData = new SaveData();
            jsonString = JsonUtility.ToJson(PlayerData);
         }
         PlayerData = new SaveData(JsonUtility.FromJson<SaveData>(jsonString));
      }
      else
      {
        // print("Save Not Found, Initializing Default Parameters");
         PlayerData = new SaveData();
         File.Create(_jsonPath);
      }
   }

   public void LoadGame()
   {
      string jsonString = "";
      
      if (File.Exists(_jsonPath))
      {
        // print("Save Found, Game Loaded");
         jsonString = File.ReadAllText(_jsonPath);
         if (string.IsNullOrEmpty(jsonString))
         {
            PlayerData = new SaveData();
            jsonString = JsonUtility.ToJson(PlayerData);
         }
         PlayerData = new SaveData(JsonUtility.FromJson<SaveData>(jsonString));
         PlayerStats.coins = PlayerData.gold;
         PlayerStats.progress = PlayerData.progress;
         if(HUDManager.Instance)HUDManager.Instance.UpdateCoins();
         //go to scene
      }
      else
      {
       //  print("No Save Found");
      }
   }

   public void SaveGame()
   {
      string jsonString = "";
      
      if (File.Exists(_jsonPath))
      {
         jsonString = JsonUtility.ToJson(PlayerData);
         File.WriteAllText(_jsonPath, jsonString);
//         print("Game Saved");
      }
      else
      {
      //   print("No Save Found, Creating a New Save");
         File.Create(_jsonPath);
         jsonString = JsonUtility.ToJson(PlayerData);
         File.WriteAllText(_jsonPath, jsonString);
       //  print("Game Saved");
      }
   }

   public void DeleteSave()
   {
      string jsonString = "";

      if (File.Exists(_jsonPath))
      {
        // print("ResettingSave");
         PlayerData = new SaveData();
         SaveGame();
      }
      else
      {
       //  print("No Save Found");
      }
   }
}
