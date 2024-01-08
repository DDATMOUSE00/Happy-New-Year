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
    private HitPlayer HitPlayer;
    //public Slider slider;
    public bool IsInvincible { get; set; }

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        HitPlayer = GetComponent<HitPlayer>();
    }

    private void Start()
    {
        //SetMaxHealth(health);
    }

    private void Update()
    {
        //if (slider != null)
        //{

        //    SetHealth(health);
        //}

        if (health <= 0)
        {
            _anim.SetBool("IsDead", true);
            Invoke("IsDead", 1f);
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

        if (CompareTag("Enemy"))
        {
            _anim.SetBool("TakeDamage", true);
        }

        if (CompareTag("Player"))
        {
            StartCoroutine(HitPlayer.InvincibilityTimer());
            ApplyKnockback(gameObject.transform);
            IsInvincible = true;
        }
    }
    private void ApplyKnockback(Transform playertransform)
    {
        Vector2 knockbackDirection = playertransform.position - transform.position;
        Vector2 rotatedKnockbackDirection = Quaternion.Euler(0, 0, 180) * knockbackDirection;

        Rigidbody2D playerRigidbody = playertransform.GetComponent<Rigidbody2D>();
        playerRigidbody.AddForce(rotatedKnockbackDirection * 3f, ForceMode2D.Impulse);
    }

    //public void SetMaxHealth(int health)
    //{
    //    //Debug.Log(slider);
    //    slider.maxValue = health;
    //    slider.value = health;
    //}

    //public void SetHealth(int health)
    //{
    //    slider.value = health;
    //}
}
