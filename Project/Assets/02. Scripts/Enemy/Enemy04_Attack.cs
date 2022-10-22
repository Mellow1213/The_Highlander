using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy04_Attack : MonoBehaviour
{
    public float spawnCoolTime = 10f;
    GameObject target;
    [SerializeField] private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnCoolTime)
        {
            Debug.Log("Àû ¼ÒÈ¯");
            timer = 0f;
        }
    }
}
