using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCharge : MonoBehaviour
{
    GameObject core;
    public float Energy;
    // Start is called before the first frame update
    void Start()
    {
        core = GameObject.Find("Energy_Cell");   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, core.transform.position, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Energy"))
        {
            GameManager.Instance.Energy += Energy;
            Destroy(gameObject);
        }
    }
}
