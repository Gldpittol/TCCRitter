using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private PlayerManager _player;
    private float _zOffset;
    private void Start()
    {
        _player = PlayerManager.Instance;
        _zOffset = transform.position.z;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _zOffset);
    }
}
