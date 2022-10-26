using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy05_Attack : MonoBehaviour
{
    GameObject target;

    float timer = 0f;
    bool attack = false;

    public GameObject[] slashWave;
    Animator _animator;
    NavMeshAgent _navMeshAgent;
    EnemyHit _enemyHit;


    public float attackDistance = 6f;
    public GameObject bulletPrefabs;
    public float FireRate = 0.8f;
    float fireTimer = 0f;
    public GameObject muzzle;

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
            if (timer > 4f && !attack)
            {
                _navMeshAgent.speed = 0f;
                _animator.SetTrigger("Spin");
                timer = 0f;
            }

            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {
                fireTimer += Time.deltaTime;
                _animator.SetBool("Shoot", true);
                _navMeshAgent.speed = 0f;
                attack = true;
                if(fireTimer >= FireRate)
                {
                    Instantiate(bulletPrefabs, muzzle.transform.position, Quaternion.identity);
                    fireTimer = 0f;
                }
            }
            else
            {
                fireTimer = 0f;
                _navMeshAgent.speed = 2f;
                attack = false;
                _animator.SetBool("Shoot", false);
            }
            transform.LookAt(target.transform);
        }
    }

    public void DoSlash()
    {
        for (int i = 0; i < slashWave.Length; i++)
            Instantiate(slashWave[i], transform.position, slashWave[i].transform.rotation);
    }
}
