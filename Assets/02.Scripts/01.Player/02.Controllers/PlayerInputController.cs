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
        Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnJump(InputValue value)
    {
        Debug.Log("OnJump" + value.ToString());
        bool IsJumpPressed = value.isPressed;
        IsJumping = IsJumpPressed;
        CallJumpEvent();
    }
    public void OnAttack(InputValue value)
    {
        Debug.Log("OnAttack" + value.ToString());
        bool IsAttackPressed = value.isPressed;
        IsAttacking = IsAttackPressed;
        CallAttackEvent();
    }
}
