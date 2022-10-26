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
    bool isLandAttack = false;

    public GameObject slashEffect;
    public Transform slashPos;
    public GameObject blastEffect;
    float blastTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Slash()
    {
        Instantiate(slashEffect, slashPos.position, slashPos.rotation);
    }
    public void JumpAttack()
    {
        Debug.Log("머쉬맘 공격!!");
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (isLandAttack)
        {
            LandBlast();
        }
        if (attackTimer > attackCoolTime)
        {
            attackState = Random.Range(2, 3);

            if (attackState == 0)
            {
                _animator.SetTrigger("Melee");
                // 검기 공격
            }
            else if (attackState == 1)
            {
                StartCoroutine(Jump());
                // 점프 충격
            }
            else
            {
                StartCoroutine(Dash());
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

    void LandBlast()
    {
        blastTimer += Time.deltaTime;
        if(blastTimer > 0.25)
        {
            Debug.Log("현재 위치에 소환");
            blastTimer = 0f;
        }
    }

    public void Land()
    {
        isLandAttack = true;
        Debug.Log("착지 공격!!");
    }

    IEnumerator Dash()
    {
        _animator.SetTrigger("Dash");
        _navMeshAgent.speed = 20f;
        Debug.Log("착지 대기!!");
        yield return new WaitUntil(() => isLandAttack);
        Debug.Log("착지 확인!!");
        _navMeshAgent.speed = 0f;
        yield return new WaitForSeconds(2.0f);
        Debug.Log("미끄러짐 끝!!");
        _navMeshAgent.speed = 0.5f;
        isLandAttack = false;
    }
}
