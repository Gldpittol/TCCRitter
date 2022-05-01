using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
   Cutscene,
   Gameplay
}

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public GameState gameState;
   private void Awake()
   {
      Instance = this;
   }
}
