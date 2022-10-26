using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy02_Attack : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _navMeshAgent;

    public float attackDistance = 3f;
    public GameObject attackVFX;
    GameObject target;
    Health _health;

    public float damage = 1f;

    bool isAttacking = false;
    bool chaseStart = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        _health = target.GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void AttackVFX()
    {
        _health.Damaged(damage);
        attackVFX.SetActive(false);
        attackVFX.SetActive(true);
    }

    public void AttackFinished()
    {
        isAttacking = false;
    }

    public void ChaseStart()
    {
        chaseStart = true;
    }

    public void Scream()
    {
        Debug.Log("추적자의 울음소리");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= attackDistance && !isAttacking)
        {
            isAttacking = true;
        }
        if (chaseStart)
        {
            if (isAttacking)
            {
                isAttacking = false;
                _animator.SetBool("Attack", true);
                _navMeshAgent.speed = 0;
            }
            else
            {
                _navMeshAgent.speed = 7;
                _animator.SetBool("Attack", false);
            }
        }
    }
}
