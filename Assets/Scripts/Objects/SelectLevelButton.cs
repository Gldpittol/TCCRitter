using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SelectLevelButton : MonoBehaviour
{
    public GameProgress minimumProgress;
    public GameObject[] relatedTraces;
    public string[] possibleSceneNames;
    private void Awake()
    {
        if ((int) PlayerStats.progress < (int) minimumProgress)
        {
            GetComponent<Image>().enabled = false;
            foreach (GameObject trace in relatedTraces)
            {
                trace.SetActive(false);
            }
        }
        else
        {
            GetComponent<Image>().enabled = true;
            foreach (GameObject trace in relatedTraces)
            {
                trace.SetActive(true);
            }
        }
    }

    public void GoToLevel()
    {
        if (possibleSceneNames.Length == 0) return;
        int rnd = Random.Range(0, possibleSceneNames.Length);
        SceneManager.LoadScene(possibleSceneNames[rnd], LoadSceneMode.Single);
    }
}
