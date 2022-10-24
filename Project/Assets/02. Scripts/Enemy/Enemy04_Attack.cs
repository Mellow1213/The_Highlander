using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy04_Attack : MonoBehaviour
{
    public float spawnCoolTime = 10f;
    GameObject target;
    [SerializeField] private float timer = 0f;
    public GameObject Dancer;
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
            Instantiate(Dancer, transform.position + SetPos(), Quaternion.identity);
            timer = 0f;
        }
    }
    Vector3 SetPos()
    {
        Vector3 pos = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        return pos;

    }
}
