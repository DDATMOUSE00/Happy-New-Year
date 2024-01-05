using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;

    [SerializeField]
    private Animator _anim;

    public Slider slider;


    private void Start()
    {
        SetMaxHealth(health);
    }

    private void Update()
    {
        //TODO 현재 hp를 보여주는 함수제작
        if(slider != null)
        {

            SetHealth(health);
        }
        
    }

    private void IsDead()
    {
        _anim.SetBool("IsDead", true);
        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("나죽어~~~");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //if (gameObject.CompareTag("Enemy")) // 플레이어에 TakeDamage 애니매이션이 있으면 조건삭제
        //{
        //    _anim.SetBool("TakeDamage", true);
        //}


        if (health <= 0)
        {
            IsDead();
        }
    }

    public void SetMaxHealth(int health)
    {
        //Debug.Log(slider);
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
