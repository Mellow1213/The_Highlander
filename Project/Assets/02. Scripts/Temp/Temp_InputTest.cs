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
            Debug.Log("���ͷ��� = f");
        if (s.ultimate)
            Debug.Log("�ñر� = q");
        if (s.skill)
            Debug.Log("������ų = e");
        if (s.weapon)
            Debug.Log("������º��� = r");
        if (s.item01)
            Debug.Log("������1 = 1");
        if (s.item02)
            Debug.Log("������2 = 2");
        if (s.item03)
            Debug.Log("������3 = 3");
        if (s.status)
            Debug.Log("�������ͽ� = TAB");
        if (s.pause)
            Debug.Log("���� = esc");
    }
}
