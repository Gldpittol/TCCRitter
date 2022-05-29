using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaff : MonoBehaviour
{
    [SerializeField] private float angleOffset = 90;
    [SerializeField] private GameObject player;

    private Vector3 offSetToPlayer;
    private void Awake()
    {
        offSetToPlayer = transform.position - player.transform.position;
    }

    void Update ()
    {
        if (GameManager.Instance.gameState != GameState.Gameplay) return;

        //int sideMultiplier = player.transform.localScale.x > 0 ? 1 : -1;
        //transform.position = player.transform.position + (new Vector3(offSetToPlayer.x * sideMultiplier, offSetToPlayer.y, offSetToPlayer.z) );
        transform.position = player.transform.position + offSetToPlayer;
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle + angleOffset));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
