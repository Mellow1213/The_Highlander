using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantJumpDamage : MonoBehaviour
{
    public float damage = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Damaged(damage);
        }
    }
}
