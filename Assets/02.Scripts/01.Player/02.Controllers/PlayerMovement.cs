using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _controller;
    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    public bool IsGrounded = false;
    public bool IsJumping = false;
    public Animator anim;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;


    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnJumpEvent += Jump;
    }
    private void FixedUpdate()
    {
        CheckGrounded();
        ApplyMovment(_movementDirection);

        if (IsGrounded)
        {
            IsJumping = false;
            anim.SetBool("IsJump", false);
        }
        else
        {
            anim.SetBool("IsJump", true);
        }
    }
    private void CheckGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
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

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("IsMove", true);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }
    }
    private void Jump()
    {
        if (IsGrounded && !IsJumping)
        {
            _rigidbody.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
            IsJumping = true;
            anim.SetBool("IsJump", true);
        }
        Debug.Log("OnJump2" + ToString());
    }

}
