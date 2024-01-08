using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    private Animator _anim;
    public Slider slider;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        //SetMaxHealth(health);
    }

    private void Update()
    {
        if (slider != null)
        {

            SetHealth(health);
        }

        if (health <= 0)
        {
            _anim.SetBool("IsDead", true);
            Invoke("IsDead",1f);
        }
    }

    private void IsDead()
    {
        if (CompareTag("Enemy"))
        {
            GameManager.Instance.experience = 1;
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
        if (CompareTag("Enemy")) // 플레이어에 TakeDamage 애니매이션이 있으면 조건삭제
        {
            _anim.SetBool("TakeDamage", true);
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
