using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    
    private PlayerManager _player;
    private float _zOffset;
    public float lerpTiming = 0.5f;
    public float lerpZoom = 0.1f;
    private bool canLerpSize = false;
    private float _newSize;
    private Camera cam;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _player = PlayerManager.Instance;
        _zOffset = transform.position.z;
    }

    private void LateUpdate()
    {
        if(!cam) cam = GetComponent<Camera>();
        
        Vector3 lerpVector = new Vector3(_player.transform.position.x, _player.transform.position.y, _zOffset);
        transform.position = Vector3.Lerp(transform.position, lerpVector, lerpTiming);
        if (canLerpSize)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, _newSize, lerpZoom);
        }
    }

    public void LerpSize(float newSize)
    {
        _newSize = newSize;
        canLerpSize = true;
    }

    public void FinishLerp()
    {
        Vector3 lerpVector = new Vector3(_player.transform.position.x, _player.transform.position.y, _zOffset);
        transform.position = lerpVector;
    }
}
