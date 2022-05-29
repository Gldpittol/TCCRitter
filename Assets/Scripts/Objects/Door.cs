using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Door : MonoBehaviour
{
    public static Door Instance;
    
    public List<string> possibleScenes;
    private bool isCollidingWithPlayer;
    private SpriteRenderer sr;
    private BoxCollider2D boxCol;
    private bool isOpen = false;

    private void Awake()
    {
        Instance = this;
        sr = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        sr.enabled = false;
        boxCol.enabled = false;
    }

    private void Update()
    {
        if (!isCollidingWithPlayer) return;
        if (!isOpen) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            int newSceneID = Random.Range(0, possibleScenes.Count);
            SceneManager.LoadScene(possibleScenes[newSceneID], LoadSceneMode.Single);
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

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorCoroutine());
    }

    public IEnumerator OpenDoorCoroutine()
    {
        yield return null;
        sr.enabled = true;
        boxCol.enabled = true;
        isOpen = true;
        PlayerMovement.Instance.ChangeFKeyVisibility(false);
    }
}
