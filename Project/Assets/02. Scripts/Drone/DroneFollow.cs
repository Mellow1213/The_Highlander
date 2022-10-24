using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DroneFollow : MonoBehaviour
{
    public GameObject followTarget;
    public float moveSpeed;
    GameObject player;

    public GameObject spinPoint;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, followTarget.transform.position);
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, followTarget.transform.position, moveSpeed * Time.deltaTime * distance);

        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time) * 1.4f * Time.deltaTime, transform.position.z);

        if (distance <= 0.5f)
        {
            transform.RotateAround(spinPoint.transform.position, Vector3.up, Time.deltaTime *30) ;
        }
        else
        {
            Vector3 dir = Vector3.Lerp(transform.forward, transform.position - followTarget.transform.position, 6*Time.deltaTime);
            dir.y = 0;

            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;
        }

    }
}
