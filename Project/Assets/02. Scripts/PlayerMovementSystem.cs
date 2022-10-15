using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerMovementSystem : MonoBehaviour
{
    private ThirdPersonShooterController _thirdPersonShooterController;
    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _input;
    private CharacterController _controller;
    private void Start()
    {
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<CharacterController>();
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
                //Debug.Log("���Ÿ� ���� ����");
            }
            else
            {
                //Debug.Log("���� ���� ����");
            }
            _input.attack = false;
        }
    }


}
