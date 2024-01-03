using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider; //본인
    private Animator _anim;
    [SerializeField] private int damage;
    [SerializeField] private float delay = 0.5f;
    private float dTime;
    private int comboAttack;

    public GameObject hitBox;
    public Vector2 hitBoxSize;

    private void Awake()
    {
        //damage = 몬스터 마다의 공격력
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(hitBox.transform.position, hitBoxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            Debug.Log(collider.tag);
            ChangeHitBox();
            if (collider.gameObject.CompareTag("Player") && dTime <= 0)
            {
                if (collider.TryGetComponent(out Health health))
                {
                    OnAttack();
                    //플레이어의 health스크립트를 가져와서 데미지를 넣어준다.
                    health.TakeDamage(damage);
                }
                dTime = delay;
            }
        }
        dTime -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(hitBox.transform.position, hitBoxSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }

    private void ChangeHitBox()
    {
        hitBox.transform.position = new Vector3(-1,0,0); 
    }

    private void OnAttack()
    {
        if (comboAttack == 0)
        {
            _anim.SetBool("Attack1", true);
            comboAttack++;
        }
        else
        {
            _anim.SetBool("Attack2", true);
            comboAttack = 0;
        }
        Invoke("UnAttack", 1f);
    }

    private void UnAttack()
    {
        if(comboAttack == 1)
            _anim.SetBool("Attack1", false);
        else
            _anim.SetBool("Attack2", false);
    }
}
