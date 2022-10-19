using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerAttackSystem : MonoBehaviour
{
    private ThirdPersonShooterController _thirdPersonShooterController;
    private StarterAssetsInputs _input;
    private Animator _animator;
    private LineRenderer _lineRenderer;

    public GameObject Gun;
    public GameObject Sword;
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
        _lineRenderer.enabled = false;
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
                StartCoroutine(CreateShotLine());
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

    IEnumerator CreateShotLine()
    {
        _lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.03f);
        _lineRenderer.enabled = false;
    }

    void ChangeWeapon()
    {
        if (_input.aiming)
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
