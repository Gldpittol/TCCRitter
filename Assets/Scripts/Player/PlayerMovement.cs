using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    
    private GameObject FKey;
    private PlayerAnimations _playerAnimations;
    private Rigidbody2D _rigidBody;
    private AudioSource _audSource;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _audSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        FKey = PlayerManager.Instance.exclamationMark;
    }

    private void Update()
    {
        //if(GameManager.Instance.gameState == GameState.Gameplay) DecideSide();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameState.Gameplay) MoveCharacter();
        else
        {
            _rigidBody.velocity = new Vector2(0, 0);
            _playerAnimations.SetIdle();
            _audSource.enabled = false;
        }
    }

    private void DecideSide()
    {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float myPosX = transform.position.x;
        
        if ((mousePosX > myPosX) && transform.localScale.x < 0)
        {
            FKey.transform.parent = null;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            FKey.transform.parent = transform;

        }
        else if ((mousePosX < myPosX) && transform.localScale.x >0)
        {
            FKey.transform.parent = null;
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            FKey.transform.parent = transform;
        }
    }
    private void MoveCharacter()
    {
        _rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")).normalized * speed * PlayerStats.movementSpeedMultiplier;

        if (_rigidBody.velocity != Vector2.zero && !_audSource.enabled) _audSource.enabled = true;
        if (_rigidBody.velocity == Vector2.zero && _audSource.enabled) _audSource.enabled = false;
    }
}
