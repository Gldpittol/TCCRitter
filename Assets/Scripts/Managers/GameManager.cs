using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
   Cutscene,
   Gameplay,
   Paused
}

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public GameState gameState;
   public int amountOfLevels = 15;
   private void Awake()
   {
      Instance = this;
   }

   public void LoadScene(Image fadeImage, float fadeTime, string sceneName)
   {
      StartCoroutine(LoadSceneCoroutine(fadeImage, fadeTime, sceneName));
   }
   public IEnumerator LoadSceneCoroutine(Image fadeImage, float fadeTime, string sceneName)
   {
      Time.timeScale = 1;
      FadeIn(fadeImage, fadeTime);
      while (fadeImage.enabled)
      {
         yield return null;
      }

      fadeImage.enabled = true;

      SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
   }
   
   public void FadeIn(Image fadeImage, float fadeTime)
   {
      fadeImage.enabled = true;
      fadeImage.DOFade(0,0).OnComplete(()=>fadeImage.DOFade(1,fadeTime).OnComplete(()=>fadeImage.enabled = false));
   }
   public void FadeOut(Image fadeImage, float fadeTime)
   {
      fadeImage.enabled = true;
      fadeImage.DOFade(1,0).OnComplete(()=>fadeImage.DOFade(0,fadeTime).OnComplete(()=>fadeImage.enabled = false));
   }
}
