using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy06_Attack : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Animator _animator;

    public float attackCoolTime = 12f;
    float attackTimer = 3f;
    int attackState;
    bool isLandAttack = false;

    public GameObject slashEffect;
    public Transform slashPos;
    public GameObject blastEffect;
    public GameObject[] jumpEffect;
    float blastTimer = 0f;
    Health _health;
    EnemyHit _enemyHit;
    // Start is called before the first frame update
    void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _enemyHit = GetComponent<EnemyHit>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Slash()
    {
        Instantiate(slashEffect, slashPos.position, slashPos.rotation);
    }
    public IEnumerator JumpAttack()
    {
        Instantiate(jumpEffect[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(jumpEffect[1], transform.position, transform.rotation);
    }

    bool stop = false;
    // Update is called once per frame
    void Update()
    {
        if(!_enemyHit.death)
            attackTimer += Time.deltaTime;
        if (isLandAttack)
        {
            LandBlast();
        }
        if (attackTimer > attackCoolTime)
        {
            attackState = Random.Range(0, 3);

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
        if (blastTimer > 0.1f)
        {
            Instantiate(blastEffect, transform.position, transform.rotation);
            blastTimer = 0f;
        }
        if (_health.isDeath && !stop)
        {
            stop = true;
            transform.position += transform.forward * 3f;
            _navMeshAgent.enabled = false;
        }
    }

    public void Land()
    {
        isLandAttack = true;
    }

    IEnumerator Dash()
    {
        _animator.SetTrigger("Dash");
        _navMeshAgent.speed = 20f;
        yield return new WaitUntil(() => isLandAttack);
        _navMeshAgent.speed = 0f;
        yield return new WaitForSeconds(1.5f);
        _navMeshAgent.speed = 0.5f;
        isLandAttack = false;
    }
}
