using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    GameObject player;
    Vector3 playerPos;
    Vector3 myPos;
    Vector3 targetVector;
    public float speed = 10f;
    public float bulletDamage = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        myPos = transform.position;
        targetVector = playerPos - myPos;
        targetVector = targetVector.normalized;
        targetVector.y = 0f;
        transform.LookAt(playerPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetVector * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<Health>().isInvade)
            {
                other.GetComponent<Health>().Damaged(bulletDamage);
                Destroy(gameObject);
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }
        else if(!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }

}
