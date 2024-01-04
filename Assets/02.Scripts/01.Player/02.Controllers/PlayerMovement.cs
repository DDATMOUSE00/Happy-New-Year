using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnJumpEvent += Jump;
    }
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }
    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 5;
        Vector2 currentVelocity = _rigidbody.velocity;
        currentVelocity.x = direction.x;

        _rigidbody.velocity = currentVelocity;
    }
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        Debug.Log("OnJump2" + ToString());
    }
    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
    }
}
