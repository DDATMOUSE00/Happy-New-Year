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
    [SerializeField] private int collDamage;
    [SerializeField] private float delay;
    private float dTime;
    private int comboAttack;
    public bool isAttack;

    public Transform hitBox;
    public Vector2 hitBoxSize;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapBox(hitBox.position, hitBoxSize, 0);
        if (collider.CompareTag("Player"))
        {
            Debug.Log(collider.tag);
            isAttack = true;
            if (collider.TryGetComponent(out Health health) && dTime <= 0)
            {
                OnAttack();
                health.TakeDamage(damage);
                dTime = delay;
            }
        }
        else
        {
            Debug.Log("z");
            isAttack = false;
        }
    dTime -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(hitBox.position, hitBoxSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            Debug.Log("asd");
            health.TakeDamage(collDamage);
        }
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
        Invoke("UnAttack", 0.8f);
    }

    private void UnAttack()
    {
        if (comboAttack == 1)
            _anim.SetBool("Attack1", false);
        else
            _anim.SetBool("Attack2", false);
    }
}
