using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerAttackSystem : MonoBehaviour
{
    private ThirdPersonShooterController _thirdPersonShooterController;
    private StarterAssetsInputs _input;
    private Animator _animator;

    public GameObject GunLookPos;

    private void Start()
    {
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
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
                transform.forward = Vector3.Lerp(transform.forward, _thirdPersonShooterController.aimDirection, Time.deltaTime * 120f); //DOTWeen���� ���߿� �� ����
                //Debug.Log("���� ���� ����");
            }
        }
    }
}
