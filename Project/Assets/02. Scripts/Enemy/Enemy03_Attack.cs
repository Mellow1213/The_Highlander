using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy03_Attack : MonoBehaviour
{
    GameObject target;

    bool sit = false;
    NavMeshAgent _navMeshAgent;
    Animator _animator;
    EnemyHit _enemyHit;

    public GameObject firePrefab;
    public Transform muzzle;

    public AudioClip a;
    public AudioSource b;
    float timer = 0.0f;
    public float fireRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<AudioSource>();
        _enemyHit = GetComponent<EnemyHit>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemyHit.death)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < 50f)
            {
                transform.LookAt(target.transform);
                timer += Time.deltaTime;
                sit = true;
                Debug.Log("공격범위");
                _navMeshAgent.speed = 0f;
                if (timer > fireRate)
                {
                    b.PlayOneShot(a);
                    timer = 0f;
                    _animator.SetTrigger("Fire");
                    Instantiate(firePrefab, muzzle.position, Quaternion.identity);
                    //실제 발사체 생성
                }
            }
            else
            {
                timer = 0f;
                sit = false;
                Debug.Log("추적");
                _navMeshAgent.speed = 1f;
            }
            _animator.SetBool("Sit", sit);
        }
    }
}
