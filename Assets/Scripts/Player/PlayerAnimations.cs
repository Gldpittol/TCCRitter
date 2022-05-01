using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public const string IdleAnim = "PlayerIdle";
    public const string RunAnim = "PlayerRun";
    public const string RunAnimBackwards = "PlayerRunBackwards";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(IdleAnim);
    }
    void Update()
    {
        if(GameManager.Instance.gameState == GameState.Gameplay) UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if ((Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0))
        {
            if ((Input.GetAxisRaw("Horizontal") < 0) && (transform.localScale.x > 0)) _animator.Play(RunAnimBackwards);
            else if ((Input.GetAxisRaw("Horizontal") > 0) && (transform.localScale.x < 0)) _animator.Play(RunAnimBackwards);
            else _animator.Play(RunAnim);
        }

        if ((Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0))
        {
            _animator.Play(IdleAnim);
        }
    }

    public void SetIdle()
    {
        _animator.Play("PlayerIdle");
    }
}
