using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class EnemyWaveSystem : MonoBehaviour
{
    public GameObject enemy01;
    StarterAssetsInputs _starterAssetsInputs;
    bool isCoroutineRun = false;

    private void Start()
    {
        _starterAssetsInputs = GameObject.Find("PlayerArmature").GetComponent<StarterAssetsInputs>();
    }

    public void WaveStart()
    {
        if(!isCoroutineRun)
            StartCoroutine(StartWave(3));
    }

    IEnumerator StartWave(int waveCount)
    {
        isCoroutineRun = true;
        Debug.Log("�� ����. ���̺� ����");
        for(int i = 0; i<waveCount; i++)
        {
            Debug.Log(i+ "��° ���̺� ����");
            CreateEnemy(enemy01, 3);
            
            yield return new WaitForSeconds(3f);
        }
        Debug.Log("�� ����. ���̺� ����");
        isCoroutineRun = false;
    }


    void CreateEnemy(GameObject type, int Amount)
    {
        for(int i = 0; i< Amount; i++)
        {
            Debug.Log(type + " Ÿ���� �� ��ȯ");
            Instantiate(type, transform.position, type.transform.rotation);
        }
    }
}
