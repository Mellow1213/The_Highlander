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
    public GameObject bullet;
    public Transform muzzlePos;
    public AudioClip fireSound;
    AudioSource audioSource;
    
    public float fireRate = 0.8f;
    float fireTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) <= 36)
            {
                _animator.SetBool("Fire", true);
                _navMeshAgent.speed = 0.4f;
                fireTimer += Time.deltaTime;
                if(fireTimer > fireRate)
                {
                    fireTimer = 0f;
                    Instantiate(bullet, muzzlePos.position, Quaternion.identity);
                    audioSource.PlayOneShot(fireSound);
                }
            }
            else
            {
                _navMeshAgent.speed = 1f;
                _animator.SetBool("Fire", false);
            }
        }
    }
}
