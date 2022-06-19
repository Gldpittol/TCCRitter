using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public float speed;
    
    private SpriteRenderer FKey;
    private PlayerAnimations _playerAnimations;
    private Rigidbody2D _rigidBody;
    private AudioSource _audSource;
    public float dashDelay = 2f;
    public float dashPushTime;
    public float dashForce = 10f;

    private float currentDashDelay = 0;
    private bool lastRight = false;
    private bool dashing = false;
    
    public bool beingPushed = false;
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

    private void Update()
    {
        currentDashDelay -= Time.deltaTime;
        if(HUDManager.Instance) HUDManager.Instance.UpdateDashCooldownFill(currentDashDelay, dashDelay);
    }


    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameState.Gameplay)
        {
            MoveCharacter();
            CheckDash();
        }
        else
        {
            _rigidBody.velocity = new Vector2(0, 0);
            if(_playerAnimations) _playerAnimations.SetIdle();
            _audSource.enabled = false;
        }
    }

    private void CheckDash()
    {
        if (currentDashDelay > 0) return;
        if (beingPushed) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 impulseVector = new Vector2(Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")).normalized;
            if (impulseVector == Vector2.zero)
            {
                if (lastRight) impulseVector = new Vector2(1, 0);
                else impulseVector = new Vector2(-1, 0);
            }
            
            _rigidBody.AddForce(impulseVector * dashForce, ForceMode2D.Impulse);
            dashing = true;
            StartCoroutine(ResetDashCoroutine());
            currentDashDelay = dashDelay;
        }
    }

    public IEnumerator ResetDashCoroutine()
    {
        yield return new WaitForSeconds(dashPushTime);
        dashing = false;
    }

    public void ActivatePause()
    {
        _rigidBody.velocity = new Vector2(0, 0);
        _audSource.enabled = false;
    }
    
    private void MoveCharacter()
    {
        if (beingPushed || dashing)
        {
            _audSource.enabled = false;
            return;
        }
        
        _rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")).normalized * speed * PlayerStats.movementSpeedMultiplier;

        if (Input.GetAxisRaw("Horizontal") > 0) lastRight = true;
        else if (Input.GetAxisRaw("Horizontal") < 0) lastRight = false;
        
        if (_rigidBody.velocity != Vector2.zero && !_audSource.enabled) _audSource.enabled = true;
        if (_rigidBody.velocity == Vector2.zero && _audSource.enabled) _audSource.enabled = false;
    }
}
