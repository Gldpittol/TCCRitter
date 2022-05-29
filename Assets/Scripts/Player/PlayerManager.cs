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
    }
/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fountain"))
        {
            exclamationMark.SetActive(true);
            interactablesCollisionList.Add(collision.gameObject);
        }

        if (collision.CompareTag("BuffPoster"))
        {
            exclamationMark.SetActive(true);
            interactablesCollisionList.Add(collision.gameObject);
        }

        if (collision.CompareTag("Hole"))
        {
            exclamationMark.SetActive(true);
            interactablesCollisionList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fountain"))
        {
            interactablesCollisionList.Remove(collision.gameObject);
            if(interactablesCollisionList.Count == 0) exclamationMark.SetActive(false);
        }

        if (collision.CompareTag("BuffPoster"))
        {
            interactablesCollisionList.Remove(collision.gameObject);
            if (interactablesCollisionList.Count == 0) exclamationMark.SetActive(false);
        }

        if (collision.CompareTag("Hole"))
        {
            interactablesCollisionList.Remove(collision.gameObject);
            if (interactablesCollisionList.Count == 0) exclamationMark.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && GameController.gameState == GameState.Gameplay)
        {
            HandleInteractionInput();
        }
    }

    private void HandleInteractionInput()
    {
        if(interactablesCollisionList.Count > 0)
        {
            HoleScript hole = interactablesCollisionList[0].GetComponent<HoleScript>();
            if (hole)
            {
                exclamationMark.SetActive(false);
                hole.HoleBehaviour();
            }

            FountainScript fountain = null;
            if(interactablesCollisionList.Count > 0) fountain = interactablesCollisionList[0].GetComponent<FountainScript>();
            if(fountain)
            {
                exclamationMark.SetActive(false);
                fountain.OpenFountain();
            }


            BuffsList buffScroll = null;
            if (interactablesCollisionList.Count > 0) buffScroll = interactablesCollisionList[0].GetComponent<BuffsList>();
            if (buffScroll)
            {
                exclamationMark.SetActive(false);
                buffScroll.OpenBuffPanel();
            }
        }
    }*/
}
