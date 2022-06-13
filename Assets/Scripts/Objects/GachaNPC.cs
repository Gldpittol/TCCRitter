using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaNPC : MonoBehaviour
{
    private bool isCollidingWithPlayer;
    public GameObject selectDungeonScreen;
    private void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.F))
        {
            HUDManager.Instance.OpenGachaPanel();
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
}
