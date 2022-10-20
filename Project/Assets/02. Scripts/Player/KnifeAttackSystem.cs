using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttackSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHit>().Damaged(3);
        }
    }
}
