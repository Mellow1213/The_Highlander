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
        Dodge();
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

    IEnumerator DodgeRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _input.dodge = false;
    }

    void Dodge()
    {
        if (_input.dodge)
        {
            StartCoroutine(DodgeRoutine());
            Debug.Log("구르기 실행");
        }
    }
    //_controller.Move(transform.forward.normalized* (_thirdPersonController.DodgeSpeed* Time.deltaTime) + new Vector3(0.0f, _thirdPersonController.GetVerticalVelocity(), 0.0f) * Time.deltaTime);
}
