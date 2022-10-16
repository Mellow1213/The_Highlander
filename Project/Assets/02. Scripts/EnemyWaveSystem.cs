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
        Debug.Log("문 차단. 웨이브 시작");
        for(int i = 0; i<waveCount; i++)
        {
            Debug.Log(i+ "번째 웨이브 시작");
            CreateEnemy(enemy01, 3);
            
            yield return new WaitForSeconds(3f);
        }
        Debug.Log("문 개방. 웨이브 종료");
    }


    void CreateEnemy(GameObject type, int Amount)
    {
        for(int i = 0; i< Amount; i++)
        Debug.Log(type + " 타입의 적 소환");
    }
}
