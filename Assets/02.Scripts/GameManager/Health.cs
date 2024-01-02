using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //TODO ���� hp�� �����ִ� �Լ�����

        if (health <= 0)
        {
            IsDead();
        }
    }

    private void IsDead()
    {
        anim.SetBool("IsDead", true);
        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else
        {
            // Player ������ ���ư��� �ϴ� �ڵ�?�Լ�? ����
        }
    }

    public void TakeDamage(int damage)
    {
        if (gameObject.CompareTag("Enemy")) // �÷��̾ TakeDamage �ִϸ��̼��� ������ ���ǻ���
        {
            anim.SetBool("TakeDamage", true);
        }

        health -= damage;
    }

}
