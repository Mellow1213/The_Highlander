using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy05_Attack : MonoBehaviour
{
    GameObject target;

    float timer = 0f;
    bool attack = false;

    Animator _animator;
    NavMeshAgent _navMeshAgent;
    EnemyHit _enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _enemyHit = GetComponent<EnemyHit>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, target.transform.position));
        timer += Time.deltaTime;

        if (!_enemyHit.death)
        {
            if (timer > 8f && !attack)
            {
                _navMeshAgent.speed = 0f;
                Debug.Log("회오리 공격");
                _animator.SetTrigger("Spin");
                timer = 0f;
            }

            if (Vector3.Distance(transform.position, target.transform.position) < 6f)
            {
                _animator.SetBool("Shoot", true);
                _navMeshAgent.speed = 0f;
                attack = true;
            }
            else
            {
                _navMeshAgent.speed = 2f;
                attack = false;
                _animator.SetBool("Shoot", false);
            }
            transform.LookAt(target.transform);
        }
    }
}
