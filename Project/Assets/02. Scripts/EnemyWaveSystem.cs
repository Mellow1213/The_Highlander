using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    public GameObject enemy01;
    StarterAssets.StarterAssetsInputs _starterAssetsInputs;

    private void Start()
    {
        _starterAssetsInputs = GameObject.Find("PlayerArmature").GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    public IEnumerator StartWave(int waveCount)
    {
        Debug.Log("�� ����. ���̺� ����");
        for(int i = 0; i<waveCount; i++)
        {
            Debug.Log(i+ "��° ���̺� ����");
            CreateEnemy(enemy01, 3);
            
            yield return new WaitForSeconds(3f);
        }
        Debug.Log("�� ����. ���̺� ����");
    }


    void CreateEnemy(GameObject type, int Amount)
    {
        for(int i = 0; i< Amount; i++)
        Debug.Log(type + " Ÿ���� �� ��ȯ");
    }
}
