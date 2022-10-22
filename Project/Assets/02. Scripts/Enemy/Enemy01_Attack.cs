using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy01_Attack : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Animator _animator;
    EnemyHit _enemyHit;
    GameObject target;
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
        if (!_enemyHit.death)
        {
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) <= 6)
            {
                _animator.SetBool("Fire", true);
                _navMeshAgent.speed = 0.4f;
            }
            else
            {
                _navMeshAgent.speed = 1f;
                _animator.SetBool("Fire", false);
            }
        }
    }
}
