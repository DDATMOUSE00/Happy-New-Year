using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    Vector2 dirVec = Vector2.right;
    [SerializeField] private float speed;
    private int moveCount;
    private float waitTime;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        waitTime += Time.deltaTime;
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = dirVec * speed;
        ChangeMove();
    }

    private void ChangeMove()
    {
        _anim.SetBool("Run", true);
        if (waitTime >= 5f)
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            moveCount++;
            if (moveCount % 2 == 0)
            {
                dirVec = Vector2.right;
                moveCount = 0;
            }
            else
            {
                dirVec = Vector2.left;
            }
            waitTime = 0;
        }
        else if (waitTime >= 3f)
        {
            _anim.SetBool("Run", false);
            dirVec = Vector2.zero;
        }

    }
}
