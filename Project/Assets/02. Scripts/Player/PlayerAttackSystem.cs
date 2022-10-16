using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerAttackSystem : MonoBehaviour
{
    private ThirdPersonShooterController _thirdPersonShooterController;
    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _input;
    private CharacterController _controller;

    public GameObject Gun;
    public GameObject Sword;
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
        ChangeWeapon();
    }
    void Attack()
    {
        if (_input.attack)
        {
            if (_input.aiming)
            {
                //Debug.Log("원거리 공격 실행");
            }
            else
            {
                transform.forward = Vector3.Lerp(transform.forward, _thirdPersonShooterController.aimDirection, Time.deltaTime * 120f); //DOTWeen으로 나중에 값 변경
                //Debug.Log("근접 공격 실행");
            }
            _input.attack = false;
        }
    }

    void ChangeWeapon()
    {
        if(_input.aiming)
        {
            Gun.SetActive(true);
            Sword.SetActive(false);
        }
        else 
        {
            Gun.SetActive(false);
            Sword.SetActive(true);
        }
    }

}
