using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class EnemyWaveSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] Enemies;
        public int MaxSpawnCount;
        public int MaxWaveCount;
    }

    public GameObject txt;
    public Wave[] waves;
    public DoorAction _doorAction;
    [SerializeField] public int waveLevel = 1;
    [SerializeField] public int waveCount = 0;
    [SerializeField] public float nextWaveWaitingTime;
    GameObject player;

    public int getLeftWave()
    {
        return waves[waveLevel].MaxWaveCount - waveCount;
    }
    IEnumerator SpawnWave()
    {
        // 문 닫기
        _doorAction.Close();

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
        _doorAction.Open();
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
    public GameObject startPos;
    StarterAssetsInputs _input; // 실행용 임시 Input.
    private void Start()
    {
        _input = GameObject.Find("PlayerArmature").GetComponent<StarterAssetsInputs>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(waveLevel >= 15)
        {
            GameManager.Instance.GameEnd();
        }
        if(Vector3.Distance(player.transform.position, startPos.transform.position) < 5f)
        {
            Debug.Log("웨이브 시작 가능!!");
            if (_input.interaction)
            {
                StartCoroutine(SpawnWave());
                _input.interaction = false;
            }
        }
    }
}
