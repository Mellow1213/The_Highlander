using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    Vector3 myPos;
    Vector3 targetVector;
    public float speed = 10f;
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
        Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Damaged();
        }
    }

}
