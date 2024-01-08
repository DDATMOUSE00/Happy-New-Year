using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{
    private Camera _camera;
    public void Awake()
    {
        _camera = Camera.main;
        IsJumping = true;
        IsAttacking = false;
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnJump(InputValue value)
    {
        bool IsJumpPressed = value.isPressed;
        IsJumping = IsJumpPressed;
        CallJumpEvent();
    }
    public void OnAttack(InputValue value)
    {
        bool IsAttackPressed = value.isPressed;
        IsAttacking = IsAttackPressed;
        CallAttackEvent();
    }
}
