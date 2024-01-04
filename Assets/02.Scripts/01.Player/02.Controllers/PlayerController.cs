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
    protected bool IsJumping { get; set; }
    protected bool IsAttacking { get; set; }

    protected virtual void Update()
    {
        PlayerJumpCheck();
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    private void PlayerJumpCheck()
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
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
