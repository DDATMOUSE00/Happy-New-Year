using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController _controller;
    private float AttackTime;
    public Animator anim;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Start()
    {
        _controller.OnAttackEvent += Attack;
    }
    private void Attack()
    {
        if (_controller.IsAttacking)
        {
            StartCoroutine(StartAttack());
            Debug.Log("공격키입력");
        }
    }
    IEnumerator StartAttack()
    {
        _controller.IsAttacking = true;
        anim.SetBool("IsAttack", true);
        AttackTime = 0f;
        yield return new WaitForSeconds(_controller.AttackDelay);
        AttackDMG();
        EndAttack();
        Debug.Log("공격시작");
    }
    private void AttackDMG()
    {

    }
    private void EndAttack()
    {
        _controller.IsAttacking = false;
        anim.SetBool("IsAttack", false);
        Debug.Log("공격끝");
    }
}
