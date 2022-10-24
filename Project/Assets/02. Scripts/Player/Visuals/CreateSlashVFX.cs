using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlashVFX : MonoBehaviour
{
    public GameObject[] swordVFX;
    public float doubleStabDelay = 0.4f;
    public void Slash01()
    {
        swordVFX[0].SetActive(false);
        swordVFX[0].SetActive(true);
        Debug.Log("슬래쉬 1");
    }
    public void Slash02()
    {
        swordVFX[1].SetActive(false);
        swordVFX[1].SetActive(true);
        Debug.Log("슬래쉬 2");
    }
    public void Slash03()
    {
        Debug.Log("슬래쉬 3");
    }

    public IEnumerator Slash_03()
    {
        swordVFX[2].SetActive(false);
        swordVFX[2].SetActive(true);
        yield return new WaitForSeconds(doubleStabDelay);
        swordVFX[3].SetActive(false);
        swordVFX[3].SetActive(true);
    }
}
