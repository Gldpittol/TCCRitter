using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerTrigger : MonoBehaviour
{
    public int orderWhenColliding = 11;
    public int orderDefault = -4;
    public GameObject myObject;

    private TilemapRenderer myRenderer; 
    private void Awake()
    {
        myRenderer = myObject.GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            myRenderer.sortingOrder = orderWhenColliding;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            myRenderer.sortingOrder = orderDefault;
        }
    }
}
