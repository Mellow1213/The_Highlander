using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy02_Attack : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _navMeshAgent;

    public float attackDistance = 1f;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
        {
            _navMeshAgent.enabled = false;
        }
        else 
        {
            _navMeshAgent.enabled = true;
        }
        if (target)
        {
            if(Vector3.Distance(transform.position, target.transform.position) <= attackDistance)
            {
                Debug.Log("공격");
                _animator.SetBool("Attack", true);
            }
            else
            {
                _animator.SetBool("Attack", false);
                Debug.Log("추적");
            }
        }
    }
}
