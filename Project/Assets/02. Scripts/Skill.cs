using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float Times;
    SphereCollider _sc;
    Health health;

    public float Damage;

    float timer = 0f;

    private void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _sc = GetComponent<SphereCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        health.isInvade = true;
        timer += Time.deltaTime;
        if(timer > Times)
        {
            health.isInvade = false;
            _sc.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHit>().Damaged(Damage);
        }
    }
}
