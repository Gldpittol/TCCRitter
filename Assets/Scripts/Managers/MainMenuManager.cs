using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public string mainHubSceneName = "Hub";
    public Image fadeImage;
    public int fadeTime = 1;
    public GameObject creditsPanel;
    private void Start()
    {
        GameManager.Instance.FadeOut(fadeImage, fadeTime);
    }

    public void OpenCredits()
    {
        StartCoroutine(OpenCreditsCoroutine());
    }

    public IEnumerator OpenCreditsCoroutine()
    {
        GameManager.Instance.FadeIn(fadeImage, fadeTime);
        while (fadeImage.enabled)
        {
            yield return null;
        }
        creditsPanel.SetActive(true);
        GameManager.Instance.FadeOut(fadeImage, fadeTime);
    }
    
    public void CloseCredits()
    {
        StartCoroutine(CloseCreditsCoroutine());
    }

    public IEnumerator CloseCreditsCoroutine()
    {
        GameManager.Instance.FadeIn(fadeImage, fadeTime);
        while (fadeImage.enabled)
        {
            yield return null;
        }
        creditsPanel.SetActive(false);
        GameManager.Instance.FadeOut(fadeImage, fadeTime);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameManager.Instance.LoadScene(fadeImage, fadeTime, mainHubSceneName);
    }
}
