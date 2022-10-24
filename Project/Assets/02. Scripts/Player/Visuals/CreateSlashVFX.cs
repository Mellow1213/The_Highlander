using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlashVFX : MonoBehaviour
{
    public GameObject[] swordVFX;
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
        swordVFX[2].SetActive(false);
        swordVFX[2].SetActive(true);
        Debug.Log("슬래쉬 3");
    }
}
