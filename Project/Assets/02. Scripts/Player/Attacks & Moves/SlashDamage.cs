using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDamage : MonoBehaviour
{
    BoxCollider _boxCollider;
    public float slashDamage = 4f;
    private void OnEnable()
    {
        _boxCollider = GetComponentInChildren<BoxCollider>();
        StartCoroutine(ColliderCheck());
    }

    IEnumerator ColliderCheck()
    {
        _boxCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHit>().Damaged(slashDamage);
        }
        else
        {
        }
    }
}
