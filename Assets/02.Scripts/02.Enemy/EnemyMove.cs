using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    EnemyAttack enemyAttack;
    Vector2 dirVec = Vector2.right;
    [SerializeField] private float speed;
    private int moveCount;
    private float waitTime;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;

    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        waitTime += Time.deltaTime;
        if (!enemyAttack.isAttack)
        {
            Move();
        }
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
            moveCount++;
            if (moveCount % 2 == 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                dirVec = Vector2.right;
                moveCount = 0;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
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
