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
                //Debug.Log("원거리 공격 실행");
            }
            else
            {
                transform.forward = Vector3.Lerp(transform.forward, _thirdPersonShooterController.aimDirection, Time.deltaTime * 120f); //DOTWeen으로 나중에 값 변경
                //Debug.Log("근접 공격 실행");
            }
        }
    }
}
