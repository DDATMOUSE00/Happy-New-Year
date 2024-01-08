﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController _controller;
    private Animator anim;
    public Transform AttackRangeBox;
    public Vector2 AttackRangeBoxSize;
    public Health Health;

    private int minDamage = 10;
    private int maxDamage = 20;
    private int PlayerDMG;
    private Collider2D PlayerRangeCollider;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Start()
    {
        _controller.OnAttackEvent += Attack;
    }
    private void Update()
    {
        Collider2D Playercollider = Physics2D.OverlapBox(AttackRangeBox.position, AttackRangeBoxSize, 0);
        PlayerRangeCollider = Playercollider;
    }
    private void Attack()
    {
        if (_controller.IsAttacking)
        {
            StartAttack();
        }
    }
    private void StartAttack()
    {
        _controller.IsAttacking = true;
        anim.SetBool("IsAttack", true);
        AttackRange();
    }
    private void AttackRange()
    {
        if (PlayerRangeCollider != null)
        {
            PlayerDMG = Random.Range(minDamage, maxDamage + 1);
            if (PlayerRangeCollider.CompareTag("Enemy") || PlayerRangeCollider.CompareTag("Stone"))
            {
                if (PlayerRangeCollider.TryGetComponent(out Health health))
                {
                    health.TakeDamage(PlayerDMG);
                }
            }
        }
        Invoke("EndAttack", 0.3f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(AttackRangeBox.position, AttackRangeBoxSize);
    }

    private void EndAttack()
    {
        _controller.IsAttacking = false;
        anim.SetBool("IsAttack", false);
    }
}
