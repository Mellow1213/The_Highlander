using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSalute : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("»Æ¿Œ");
            animator.SetTrigger("Salute");
        }
    }
}
