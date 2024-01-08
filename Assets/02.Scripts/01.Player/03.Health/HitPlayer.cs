using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public float knockbackForce = 3f;
    public float invincibilityTime = 4f;
    public SpriteRenderer playerSprite;
    public bool IsInvincible = false;


    public IEnumerator InvincibilityTimer()
    {
        if (IsInvincible)
        {
            playerSprite.color = new Color(200, 0, 0, 100); 
        }

        yield return new WaitForSecondsRealtime(invincibilityTime);

        if (!IsInvincible)
        {
            playerSprite.color = new Color(255, 255, 255, 255);
        }
    }
}
