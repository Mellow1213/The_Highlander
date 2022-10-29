using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    PlayerUI a;
    public string text;
    private void Start()
    {
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        a.setToolTipText(text);        
    }
    private void OnTriggerExit(Collider other)
    {
        a.setOff();
    }
}
