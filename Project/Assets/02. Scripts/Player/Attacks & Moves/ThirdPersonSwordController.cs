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
    [SerializeField] float maxComboDelay = 1.5f;

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

        if (noOfClick != 0)
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
        _animator.SetInteger("MeleeAttackState", noOfClick);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Walk Run Blend") && noOfClick == 3)
        {
            noOfClick = 0;
        }
        if (Time.time - lastClickedTime >= maxComboDelay)
        {
            noOfClick = 0;
        }
        if (Time.time - lastClickedTime > coolDownTime && AttackAllowed && _thirdPersonController.Grounded)
            if (_starterAssetsInputs.attack && !_starterAssetsInputs.aiming && (noOfClick == 0 || _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.65f))
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
            Debug.Log("콤보1 공격");
        }
        if (noOfClick == 2)
        {
            Debug.Log("콤보2 공격");
        }
        if (noOfClick == 3)
        {
            Debug.Log("콤보3 공격");
        }
        noOfClick = Mathf.Clamp(noOfClick, 0, 3);
    }

}
