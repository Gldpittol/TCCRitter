using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Resources;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
   public int totalPulls;
   public int currentPulls;
   public List<int> magicsObtained;
   public List<int> ultimatesObtained;
   public SaveData()
   {
      totalPulls = 0;
      currentPulls = 0;
      magicsObtained = new List<int>();
      ultimatesObtained = new List<int>();
   }
   public SaveData(SaveData data)
   {
      totalPulls = data.totalPulls;
      currentPulls = data.currentPulls;
      magicsObtained = new List<int>(data.magicsObtained);
      ultimatesObtained = new List<int>(data.ultimatesObtained);
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
   [SerializeField] private GachaManager _gachaManager;

   [Header("Debug")]
   [SerializeField]
   private bool _debugDataVisualization;
   [SerializeField] private SaveData _playerDataVisualization;
   
   private void Awake()
   {
      if (!Instance)
      {
         Initialize();
      }
      else
      {
         Destroy(gameObject);
      }
   }

   private void Update()
   {
      if(PlayerData != null && _debugDataVisualization) _playerDataVisualization = PlayerData;
   }

   public void Initialize()
   {
      Instance = this;
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
         print("Save Found, Game Loaded");
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
         print("Save Not Found, Initializing Default Parameters");
         PlayerData = new SaveData();
         File.Create(_jsonPath);
      }
   }

   public void LoadGame()
   {
      string jsonString = "";
      
      if (File.Exists(_jsonPath))
      {
         print("Save Found, Game Loaded");
         jsonString = File.ReadAllText(_jsonPath);
         if (string.IsNullOrEmpty(jsonString))
         {
            PlayerData = new SaveData();
            jsonString = JsonUtility.ToJson(PlayerData);
         }
         PlayerData = new SaveData(JsonUtility.FromJson<SaveData>(jsonString));
         //go to scene
      }
      else
      {
         print("No Save Found");
      }
   }

   public void SaveGame()
   {
      string jsonString = "";
      
      if (File.Exists(_jsonPath))
      {
         jsonString = JsonUtility.ToJson(PlayerData);
         File.WriteAllText(_jsonPath, jsonString);
         print("Game Saved");
      }
      else
      {
         print("No Save Found, Creating a New Save");
         File.Create(_jsonPath);
         jsonString = JsonUtility.ToJson(PlayerData);
         File.WriteAllText(_jsonPath, jsonString);
         print("Game Saved");
      }
   }

   public void DeleteSave()
   {
      string jsonString = "";

      if (File.Exists(_jsonPath))
      {
         print("ResettingSave");
         PlayerData = new SaveData();
         SaveGame();
      }
      else
      {
         print("No Save Found");
      }
   }
}
