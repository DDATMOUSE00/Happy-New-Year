using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public float knockbackForce = 3f;
    public float invincibilityTime = 2f;
    private Health Heal;
    public SpriteRenderer playerSprite;

    public void Awake()
    {
        Heal = GetComponent<Health>();
    }

    public void InvincibilityTimer()
    {
        if (Heal.IsInvincible)
        {
            playerSprite.color = new Color(200, 0, 0, 100);
        }
        else
        {
            playerSprite.color = new Color(255, 255, 255, 255);
        }
    }
}
