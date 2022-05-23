using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 offSetToPlayer;
    private void Awake()
    {
        offSetToPlayer = transform.position - player.transform.position;
    }

    void Update ()
    {
        transform.position = player.transform.position + offSetToPlayer;
    }
}
