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
                Debug.Log("��");
                break;
        }
    }

    void Phase1()
    {
        //�Ѿ� ����
        //���� ���� or ���׿�(������). ���� ������ �ٴ� ����Ʈ
    }

    void Phase2()
    {
        //1������ �ϴ� �͵� ������ ���� ��ȭ. ���� �ð� ���� ����.
        //���� �ð����� �踮�� ��ȯ. ���� �ð� �ȿ� ������ ��ü ���� ������.
        //���� �ð����� ����Ʈ ��ȯ
    }

    void Phase3()
    {
        //���߿� ����Ʈ 3���� ��ȯ
        //��� ������ٰ� �ھ� �� ���߿� ��ġ
        //����Ʈ 3���� ��ƾ� ���� ����
        //��õ� 3�䰰�� ���� �ð� ������ �й�, �� ���� ��� �� ��ƾ���
    }
}
