using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerDontDestroy : MonoBehaviour
{
    public static PlayerDontDestroy Instance;
    private List<Vector2> originalLocalPositions = new List<Vector2>();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            originalLocalPositions.Add(transform.GetChild(i).transform.localPosition);
        }

        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Respawn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = originalLocalPositions[i];
        }
    }
}
