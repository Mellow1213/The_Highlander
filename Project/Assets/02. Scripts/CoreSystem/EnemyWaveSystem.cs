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
    GameObject player;
    IEnumerator SpawnWave()
    {
        // 문 닫기

        while (waveCount < waves[waveLevel].MaxWaveCount)
        {
            waveCount++;
            for (int i = 0; i < waves[waveLevel].MaxSpawnCount; i++)
                Instantiate(waves[waveLevel].Enemies[Random.Range(0, waves[waveLevel].Enemies.Length)], SetSpawnPoint(), Quaternion.identity);
            yield return new WaitForSeconds(nextWaveWaitingTime);
        }

        while (true)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") is null)
                break;
            yield return new WaitForSeconds(1f);
        }

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
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 5f)
        {
            Debug.Log("웨이브 시작 가능!!");
            if (_input.item01)
            {
                StartCoroutine(SpawnWave());
                _input.item01 = false;
            }
        }
    }
}
