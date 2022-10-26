using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    [SerializeField] int phase = 1;

    public GameObject servant;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.Log("끝");
                break;
        }
    }

    void Phase1()
    {
        //총알 공격
        //가끔 폭발 or 메테오(레이저). 시전 직전에 바닥 이펙트
    }

    void Phase2()
    {
        //1페이즈 하는 것들 데미지 조금 강화. 시전 시간 조금 감소.
        //일정 시간마다 배리어 소환. 제한 시간 안에 못깨면 전체 범위 데미지.
        //일정 시간마다 서번트 소환
    }

    void Phase3()
    {
        //공중에 서번트 3마리 소환
        //잠깐 사라졌다가 코어 위 공중에 위치
        //서번트 3마리 잡아야 공격 가능
        //루시드 3페같이 일정 시간 지나면 패배, 그 전에 모든 피 깎아야함
    }
}
