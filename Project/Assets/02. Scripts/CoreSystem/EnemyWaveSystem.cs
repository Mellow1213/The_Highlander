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
        Debug.Log("문닫기");
        Debug.Log("웨이브 레벨 " + waveLevel + " 시작");
        while (waveCount < waves[waveLevel].MaxWaveCount)
        {
            waveCount++;
            Debug.Log("웨이브 [" + waveCount + "] 진행");
            for (int i = 0; i < waves[0].MaxSpawnCount; i++)
                Debug.Log("적 스폰");
            yield return new WaitForSeconds(nextWaveWaitingTime);
        }
        yield return new WaitWhile(() => false);
        Debug.Log("문열기");
        waveCount = 0;
        waveLevel++;
        Debug.Log("다음 웨이브 레벨은 " + waveLevel);
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
