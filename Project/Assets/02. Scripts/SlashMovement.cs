using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMovement : MonoBehaviour
{
    public int way;
    public float speed;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(way == 1)
        transform.position += Vector3.forward * Time.deltaTime * speed;
        if (way == 2)
            transform.position += Vector3.back * Time.deltaTime * speed;
        if (way == 3)
            transform.position += Vector3.left * Time.deltaTime * speed;
        if (way == 4)
            transform.position += Vector3.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Damaged(damage);
        }
    }
}
