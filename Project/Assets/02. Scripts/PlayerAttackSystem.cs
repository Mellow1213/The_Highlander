using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerAttackSystem : MonoBehaviour
{
    ThirdPersonShooterController _thirdPersonShooterController;
    private StarterAssetsInputs _input;

    private void Start()
    {
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _input = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (_input.attack)
        {
            if (_input.aiming)
            {
                Debug.Log("���Ÿ� ���� ����");
            }
            else
            {
                Debug.Log("���� ���� ����");
            }
            _input.attack = false;
        }
    }
}
