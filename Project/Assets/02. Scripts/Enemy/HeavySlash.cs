using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySlash : MonoBehaviour
{
    GameObject player;
    Health health;
    public float damage = 4f;
    public GameObject onHitParticle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 3f);
        health = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * 15f * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.Damaged(damage);
            Instantiate(onHitParticle, other.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
