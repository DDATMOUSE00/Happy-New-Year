using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Interation _inter;
    Vector3 pos = new Vector3 (1, 2, 0);
    private void Awake()
    {
        _inter = GetComponentInParent<Interation>();
    }

    private void OnEnable()
    {
        gameObject.transform.position = _inter.Player.position + pos;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(100);
        }
        Invoke("EndSpell", 1f);
    }

    private void EndSpell()
    {
        gameObject.SetActive(false);
    }

}
