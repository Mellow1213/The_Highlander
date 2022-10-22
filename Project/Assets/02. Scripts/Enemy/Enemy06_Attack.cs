using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy06_Attack : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Animator _animator;

    public float attackCoolTime = 12f;
    float attackTimer = 0f;
    int attackState;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > attackCoolTime)
        {
            attackState = Random.Range(0, 3);
            Debug.Log(attackState);

            if (attackState == 0)
            {
                _animator.SetTrigger("Melee");
                // 검기 공격
            }
            else if (attackState == 1)
            {
                StartCoroutine(Jump());
                _animator.SetTrigger("Jump");
                // 점프 충격
            }
            else
            {
                _animator.SetTrigger("Dash");
                // 점프 공격
            }
            attackTimer = 0f;
        }
    }

    IEnumerator Jump()
    {
        _animator.SetTrigger("Jump");
        _navMeshAgent.speed = 0;
        float animSpeed = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (animSpeed >= 0.99)
        {
            _navMeshAgent.speed = 0.5f;
        }
        yield return null;
    }
}
