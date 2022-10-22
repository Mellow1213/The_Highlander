using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour
{
    public float HP;
    [SerializeField] private float CurrentHP;
    public int gold;
    Animator _animator;
    NavMeshAgent _navMeshAgent;

    public bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HP;
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    public void Damaged(float damage)
    {
        CurrentHP -= damage;
    }
    void Dead()
    {
        if(CurrentHP <= 0)
        {
            if (!death)
            {
                _animator.SetTrigger("Death");
                death = true;
                _navMeshAgent.speed = 0f;
            }
            //»ç¸Á ¸ð¼Ç
            if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                Destroy(gameObject);
                GameManager.Instance.gold += 30;
            }
        }
    }
}
