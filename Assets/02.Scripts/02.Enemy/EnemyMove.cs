using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    EnemyAttack enemyAttack;
    Vector2 dirVec = Vector2.right;
    [SerializeField] private float speed;
    private int moveCount;
    private float waitTime;

    private Rigidbody2D _rigidbody;
    private Animator _anim;

    public Transform closetTarget;

    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        closetTarget = GameManager.Instance.Player;
    }

    private void Update()
    {
        if (!enemyAttack.isAttack)
        {
            waitTime += Time.deltaTime;
            Move();
        }
        else
        {
            CancelMove();
        }
    }

    private void Move()
    {
        _anim.SetBool("Run", true);
        _rigidbody.velocity = dirVec * speed;
        if (!enemy.isInteracting)
        {
            ChangeMove();
        }
        else
        {
            //플레이어의 위치로 방향전환
            dirVec = closetTarget.position - transform.position;
            if (dirVec.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            dirVec.Normalize();
        }
        
    }

    private void ChangeMove()
    {
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
            CancelMove();
        }

    }
    private void CancelMove()
    {
        _anim.SetBool("Run", false);
        dirVec = Vector2.zero;
    }
}
