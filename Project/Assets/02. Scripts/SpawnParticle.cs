using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnParticle : MonoBehaviour
{
    private void Update()
    {
        GameManager.Instance.gold += 3;

    }
}
