using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Door : MonoBehaviour
{
    public static Door Instance;
    
    public List<string> possibleScenes;
    private bool isCollidingWithPlayer;
    private Renderer sr;
    private Collider2D boxCol;
    private bool isOpen = false;
    public bool isBossDoor;
    [FormerlySerializedAs("stateAfterClearingBoss")] public GameProgress stateAfterClearing;

    private void Awake()
    {
        Instance = this;
        sr = GetComponent<Renderer>();
        boxCol = GetComponent<Collider2D>();
        sr.enabled = false;
        boxCol.enabled = false;
    }

    private void Update()
    {
        if (!isCollidingWithPlayer) return;
        if (!isOpen) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (HUDManager.Instance.FadeImage.gameObject.GetComponent<Image>().enabled) return;

            int newSceneID = Random.Range(0, possibleScenes.Count);
            var newScene = possibleScenes[newSceneID];

            if (!isBossDoor)
            {
                PlayerStats.currentFloor++;
                if (PlayerStats.currentFloor > GameManager.Instance.amountOfLevels)
                {
                    if ((int)stateAfterClearing > (int)PlayerStats.progress)
                    {
                        PlayerStats.progress = stateAfterClearing;
                        if (SaveLoadManager.Instance)
                        {
                            SaveLoadManager.PlayerData.progress = PlayerStats.progress;
                            SaveLoadManager.Instance.SaveGame();
                        }
                    }

                    PlayerStats.invulnerabilityRemaining = 0;
                    GameManager.Instance.LoadScene(HUDManager.Instance.FadeImage,HUDManager.Instance.FadeTime,"MagePoliceDepartment");
                }
                else
                {
                    PlayerStats.invulnerabilityRemaining = 0;
                    GameManager.Instance.LoadScene(HUDManager.Instance.FadeImage,HUDManager.Instance.FadeTime,newScene);
                }
            }
            else
            {
                if ((int)stateAfterClearing > (int)PlayerStats.progress)
                {
                    PlayerStats.progress = stateAfterClearing;
                    if (SaveLoadManager.Instance)
                    {
                        SaveLoadManager.PlayerData.progress = PlayerStats.progress;
                        SaveLoadManager.Instance.SaveGame();
                    }
                }       
                PlayerStats.invulnerabilityRemaining = 0;
                GameManager.Instance.LoadScene(HUDManager.Instance.FadeImage,HUDManager.Instance.FadeTime,"MagePoliceDepartment");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            PlayerMovement.Instance.ChangeFKeyVisibility(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            PlayerMovement.Instance.ChangeFKeyVisibility(false);
        }
    }

    public void OpenDoor()
    {
        sr.enabled = true;
        boxCol.enabled = true;
        isOpen = true;
        PlayerMovement.Instance.ChangeFKeyVisibility(false);
    }
}
