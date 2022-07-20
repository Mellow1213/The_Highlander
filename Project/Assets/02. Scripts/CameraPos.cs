using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject target;

    Vector3 targetPos;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.transform.position;
        offset = targetPos - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if(targetPos == null)
            targetPos = GameObject.Find("Player").transform.position;


        Vector3 camPos = new Vector3(targetPos.x + offset.x, targetPos.y + offset.y, targetPos.z + offset.z);
        transform.position = camPos;

        transform.LookAt(targetPos);
    }
}
