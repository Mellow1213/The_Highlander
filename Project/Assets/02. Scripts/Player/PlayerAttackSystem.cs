using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerAttackSystem : MonoBehaviour
{
    private ThirdPersonShooterController _thirdPersonShooterController;
    private StarterAssetsInputs _input;
    private Animator _animator;

    public GameObject Gun;
    public GameObject Sword;
    private void Start()
    {
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
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
                //Debug.Log("���Ÿ� ���� ����");
            }
            else
            {
                transform.forward = Vector3.Lerp(transform.forward, _thirdPersonShooterController.aimDirection, Time.deltaTime * 120f); //DOTWeen���� ���߿� �� ����
                //Debug.Log("���� ���� ����");
            }
            _input.attack = false;
        }
    }

    void ChangeWeapon()
    {
        if(_input.aiming)
        {

            _animator.SetBool("isAiming", _input.aiming);
            Gun.SetActive(true);
            Sword.SetActive(false);
        }
        else
        {
            _animator.SetBool("isAiming", false);
            Gun.SetActive(false);
            Sword.SetActive(true);
        }
    }
}
