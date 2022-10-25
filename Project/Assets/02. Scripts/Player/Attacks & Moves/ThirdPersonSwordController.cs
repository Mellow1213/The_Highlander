using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ThirdPersonSwordController : MonoBehaviour
{
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    private ThirdPersonShooterController _thirdPersonShooterController;
    public float coolDownTime = 2f;
    private ThirdPersonController _thirdPersonController;
    [SerializeField] private static int noOfClick = 0;
    [SerializeField] float lastClickedTime = 0;
    [SerializeField] float maxComboDelay = 2.5f;

    public GameObject sword;
    public bool AttackAllowed = true;
    BoxCollider swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        swordCollider = sword.GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (noOfClick == 0)
        {
            swordCollider.enabled = false;
        }
        else
            swordCollider.enabled = true;

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Melee"))
        {
            _thirdPersonController.DodgeAllowed = false;
            _thirdPersonController.JumpAllowed = false;
            _thirdPersonController.MoveAllowed = false;
            _thirdPersonShooterController.AimAllowed = false;
        }
        else
        {
            _thirdPersonController.DodgeAllowed = true;
            _thirdPersonController.JumpAllowed = true;
            _thirdPersonController.MoveAllowed = true;
            _thirdPersonShooterController.AimAllowed = true;
        }
                        
        if (Time.time - lastClickedTime >= maxComboDelay)
        {
            noOfClick = 0;
        }

        if ((Time.time - lastClickedTime) > coolDownTime && AttackAllowed && _thirdPersonController.Grounded)
            if (_starterAssetsInputs.attack && !_starterAssetsInputs.aiming)
            {
                Debug.Log("버튼 눌림");
                DoAttack();
                _starterAssetsInputs.attack = false;
            }
    }

    void DoAttack()
    {
        lastClickedTime = Time.time;
        noOfClick++;
        if (noOfClick == 1)
        {
            _animator.SetInteger("MeleeAttackState", 1);
        }
        if (noOfClick == 2)
        {
            _animator.SetInteger("MeleeAttackState", 2);
        }
        if (noOfClick == 3)
        {
            _animator.SetInteger("MeleeAttackState", 3);
            noOfClick = 0;
        }
        _animator.SetTrigger("MeleeAttack");
        noOfClick = Mathf.Clamp(noOfClick, 0, 3);
    }

}
