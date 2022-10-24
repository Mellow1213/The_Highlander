using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Bullet"))
        {
            Destroy(hit.gameObject);
            Damaged();
        }
    }

    public void Damaged()
    {
        Debug.Log("¾Æ¾ß");
    }
}
