using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Health _bossHealth;
    private Animator _anim;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject spell;
    float _health;
    public int castCount;

    private void Awake()
    {
        _bossHealth = GetComponent<Health>();
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
        _health = _bossHealth.health * 0.9f;
    }

    private void Update()
    {
        if (_health > _bossHealth.health)
        {
            _health -= 10f;
            Pattern();
            if (castCount == 3)
            {
                Cast();
            }
        }
    }

    private void Pattern()
    {
        Vector3 originPosition = stone.transform.position;
        int randX = Random.Range(0, 39);
        Vector3 RandomPostion = new Vector3(randX, 0, 0);
        Vector3 respawnPosition = originPosition + RandomPostion;

        Instantiate(stone, respawnPosition, Quaternion.identity);
        castCount++;
    }

    private void Cast()
    {
        _anim.SetBool("Cast", true);
        Invoke("Spell", 1.2f);
    }

    private void Spell()
    {
        _anim.SetBool("Cast", false);
        spell.SetActive(true);
        castCount = 0;
    }
}
