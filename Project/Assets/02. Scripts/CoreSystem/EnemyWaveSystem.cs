using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class EnemyWaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] Enemies;
        public int MaxSpawnCount;
        public int MaxWaveCount;
    }

    public Wave[] waves;


    [SerializeField] int waveLevel = 1;
    [SerializeField] int waveCount = 0;
    [SerializeField] public float nextWaveWaitingTime;

    IEnumerator SpawnWave()
    {
        Debug.Log("���ݱ�");
        Debug.Log("���̺� ���� " + waveLevel + " ����");
        while (waveCount < waves[waveLevel].MaxWaveCount)
        {
            waveCount++;
            Debug.Log("���̺� [" + waveCount + "] ����");
            for (int i = 0; i < waves[0].MaxSpawnCount; i++)
                Debug.Log("�� ����");
            yield return new WaitForSeconds(nextWaveWaitingTime);
        }
        yield return new WaitWhile(() => false);
        Debug.Log("������");
        waveCount = 0;
        waveLevel++;
        Debug.Log("���� ���̺� ������ " + waveLevel);
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }
    private void Update()
    {
        if (GameObject.Find("PlayerArmature").GetComponent<StarterAssetsInputs>().dodge)
            StartCoroutine(SpawnWave());
    }
}
