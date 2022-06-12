using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class AttractorField : MonoBehaviour
{
    public static AttractorField Instance;
    private List<Rigidbody2D> pullList = new List<Rigidbody2D>();
    public float pullMagnitude = 10f;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       AddToList(PlayerManager.Instance.gameObject);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < pullList.Count; i++)
        {
            if (pullList[i])
            {
                Vector3 pullVector = transform.position - pullList[i].gameObject.transform.position;
                pullList[i].AddForce(pullVector * pullMagnitude);
            }
        }
    }

    public void AddToList(GameObject obj)
    {
        pullList.Add(obj.GetComponent<Rigidbody2D>());
    }

    public void RemoveFromList(GameObject obj)
    {
        pullList.Remove(obj.GetComponent<Rigidbody2D>());

    }
}
