using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Attack : MonoBehaviour
{
    [SerializeField] int phase = 1;
    [SerializeField] float health;
    [SerializeField] bool death = false;
    Animator _animator;
    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!death)
            switch (phase)
            {
                case 1:
                    Phase1();
                    break;
                case 2:
                    Phase2();
                    break;
                case 3:
                    Phase3();
                    break;
                default:
                    Debug.Log("끝");
                    break;
            }
        else if(phase <= 3)
        {
            phase++;
            death = false;
        }
        else
        {
            Death();
        }
    }


    void Death()
    {
        Debug.Log("최종 사망");
    }

    void EndGame()
    {
        Debug.Log("플레이어 패배");
    }

    public GameObject muzzle;
    public GameObject bullet;
    public float fireDelay;
    float fireTimer = 0f;
    public GameObject explosion;
    public GameObject laser;
    public float skillDelay;
    float skillTimer = 0;

    bool phase1Start = false;
    void Phase1()
    {
        if (!phase1Start)
        {
            phase1Start = true;
        }
        //총알 공격
        //가끔 폭발 or 메테오(레이저). 시전 직전에 바닥 이펙트
    }

    public GameObject barrier;
    public float barrierSpawnDelay;
    float barrierSpawnTimer = 0f;
    public GameObject servant;
    bool phase2Start = false;

    void Phase2()
    {
        if (!phase2Start)
        {
            phase2Start = true;
        }
        //1페이즈 하는 것들 데미지 조금 강화. 시전 시간 조금 감소.
        //일정 시간마다 배리어 소환. 제한 시간 안에 못깨면 전체 범위 데미지.
        //일정 시간마다 서번트 소환
    }

    public GameObject flyServant;
    public Transform phase3Position;
    bool allowAttacked = false;

    public float endGameDelay;
    float endGameTimer = 0f;
    bool phase3Start = false;
    void Phase3()
    {
        if (!phase3Start)
        {
            phase3Start = true;
        }
        endGameTimer += Time.deltaTime;
        if (endGameTimer >= endGameDelay)
        {
            EndGame();
        }
        //공중에 서번트 3마리 소환
        //잠깐 사라졌다가 코어 위 공중에 위치
        //서번트 3마리 잡아야 공격 가능
        //루시드 3페같이 일정 시간 지나면 패배, 그 전에 모든 피 깎아야함
    }

}
