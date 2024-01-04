using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;
    public event Action OnAttackEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
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
