using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int trapDamage = 3;
    public float knockbackForce = 3f;
    public float invincibilityTime = 2f;
    public SpriteRenderer playerSprite;

    private bool isInvincible = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isInvincible)
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(trapDamage);
                ApplyKnockback(collision.transform);
                StartCoroutine(InvincibilityTimer());
            }
        }
    }

    // Color ��ȯ�� ������ ���Ŀ� Player ��ũ��Ʈ�� Health ��ũ��Ʈ���� ó���ϰ� ������ �����Դϴ�.
    private IEnumerator InvincibilityTimer()
    {
        isInvincible = true;
        playerSprite.color = new Color(200, 0, 0, 100);

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
        playerSprite.color = new Color(255, 255, 255, 255);
}

    private void ApplyKnockback(Transform playertransform)
    {
        Vector2 knockbackDirection = playertransform.position - transform.position;
        Vector2 rotatedKnockbackDirection = Quaternion.Euler(0, 0, 180) * knockbackDirection;

        Rigidbody2D playerRigidbody = playertransform.GetComponent<Rigidbody2D>();
        playerRigidbody.AddForce(rotatedKnockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
