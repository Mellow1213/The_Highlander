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
        // 문 닫기

        while (waveCount < waves[waveLevel].MaxWaveCount)
        {
            waveCount++;
            for (int i = 0; i < waves[waveLevel].MaxSpawnCount; i++)
                Instantiate(waves[waveLevel].Enemies[0], SetSpawnPoint(), Quaternion.identity);
            yield return new WaitForSeconds(nextWaveWaitingTime);
        }
        yield return new WaitWhile(() => false); // 몬스터 다 죽었다는 조건 달기

        // 문 열기
        waveCount = 0;
        waveLevel++;
    }

    Vector3 SetSpawnPoint()
    {
        Vector3 pos = new Vector3(Random.Range(-25, 15), -3.4f ,Random.Range(15, 56));
        if (pos.x < 3 && pos.x > -10 && pos.z < 30 && pos.z > 40)
            return SetSpawnPoint();
        else
            return pos;
    }

    StarterAssetsInputs _input; // 실행용 임시 Input.
    private void Start()
    {
        _input = GameObject.Find("PlayerArmature").GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        if (_input.item01)
            StartCoroutine(SpawnWave());
    }
}
