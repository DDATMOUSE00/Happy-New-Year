using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;
    public event Action OnAttackEvent;
    private float AttackTime;
    public float AttackDelay = 0.5f;
    public  bool IsJumping { get; set; }
    public bool IsAttacking { get; set; }

    protected virtual void Update()
    {
        PlayerJumpCheck();
        PlayerAttackCheck();
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void PlayerJumpCheck()
    {
        if (IsJumping == false)
        {
            CallJumpEvent();
        }
    }
    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }
    public void PlayerAttackCheck()
    {
        if (IsAttacking == false)
        {
            CallAttackEvent();
        }
    }
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
