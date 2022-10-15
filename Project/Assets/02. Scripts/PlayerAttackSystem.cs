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
                Debug.Log("원거리 공격 실행");
            }
            else
            {
                Debug.Log("근접 공격 실행");
            }
            _input.attack = false;
        }
    }
}
