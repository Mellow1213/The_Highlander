using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class temp : MonoBehaviour
{
    StarterAssetsInputs s;
    private void Start()
    {
        s = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (s.interaction)
            Debug.Log("인터랙션 = f");
        if (s.ultimate)
            Debug.Log("궁극기 = q");
        if (s.skill)
            Debug.Log("전투스킬 = e");
        if (s.weapon)
            Debug.Log("무기상태변경 = r");
        if (s.item01)
            Debug.Log("아이템1 = 1");
        if (s.item02)
            Debug.Log("아이템2 = 2");
        if (s.item03)
            Debug.Log("아이템3 = 3");
        if (s.status)
            Debug.Log("스테이터스 = TAB");
        if (s.pause)
            Debug.Log("정지 = esc");
    }
}
