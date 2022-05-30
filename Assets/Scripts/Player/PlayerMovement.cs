using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public float speed;
    
    private SpriteRenderer FKey;
    private PlayerAnimations _playerAnimations;
    private Rigidbody2D _rigidBody;
    private AudioSource _audSource;
    private void Awake()
    {
        if (PlayerDontDestroy.Instance && PlayerDontDestroy.Instance.gameObject != transform.parent.gameObject) return;
        Instance = this;
        _rigidBody = GetComponent<Rigidbody2D>();
        _audSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        FKey = PlayerManager.Instance.exclamationMark.GetComponent<SpriteRenderer>();
    }

    public void ChangeFKeyVisibility(bool active)
    {
        if(!FKey) FKey = PlayerManager.Instance.exclamationMark.GetComponent<SpriteRenderer>();
        FKey.enabled = active;
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

    public void ActivatePause()
    {
        _rigidBody.velocity = new Vector2(0, 0);
        _audSource.enabled = false;
    }
    
    private void MoveCharacter()
    {
        _rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")).normalized * speed * PlayerStats.movementSpeedMultiplier;

        if (_rigidBody.velocity != Vector2.zero && !_audSource.enabled) _audSource.enabled = true;
        if (_rigidBody.velocity == Vector2.zero && _audSource.enabled) _audSource.enabled = false;
    }
}
