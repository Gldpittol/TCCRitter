using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public const string IdleAnimBack = "IdleBack";
    public const string IdleAnimFront = "IdleFront";
    public const string RunAnimBack = "RunBack";
    public const string RunAnimFront = "RunFront";
    public const string RunAnimBackwards = "PlayerRunBackwards";
    public bool isBackAnim = true;

    private Animator _animator;
    private SpriteRenderer _sr;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _animator.Play(IdleAnimBack);
    }
    void Update()
    {
        if(GameManager.Instance.gameState == GameState.Gameplay) UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if ((vertical != 0 || horizontal != 0))
        {
            //if ((Input.GetAxisRaw("Horizontal") < 0) && (transform.localScale.x > 0)) _animator.Play(RunAnimBackwards);
            //else if ((Input.GetAxisRaw("Horizontal") > 0) && (transform.localScale.x < 0)) _animator.Play(RunAnimBackwards);
            //else _animator.Play(RunAnim);

            if (vertical > 0)
            {
                _animator.Play(RunAnimBack);
                isBackAnim = true;
            }
            if (vertical < 0)
            {
                _animator.Play(RunAnimFront);
                isBackAnim = false;
            }
            if (vertical == 0)
            {
                if(isBackAnim) _animator.Play(RunAnimBack);
                else _animator.Play(RunAnimFront);
            }
        }

        if ((Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0))
        {
            SetIdle();
        }

        CheckSide();
    }

    public void CheckSide()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float additionalMultiplier = isBackAnim ? 1 : -1;
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1 * additionalMultiplier, transform.localScale.y,
                transform.localScale.z);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1 * additionalMultiplier, transform.localScale.y,
                transform.localScale.z);
        }
    }

    public void SetIdle()
    {
        if(isBackAnim) _animator.Play(IdleAnimBack);
        else _animator.Play(IdleAnimFront);
    }
}
