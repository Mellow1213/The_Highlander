using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ThirdPersonSwordController : MonoBehaviour
{
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    public float coolDownTime = 2f;
    [SerializeField] private static int noOfClick = 0;
    [SerializeField] float lastClickedTime = 0;
    [SerializeField] float maxComboDelay = 1.5f;

    public GameObject sword;
    BoxCollider swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        swordCollider = sword.GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (noOfClick == 0)
        {
            swordCollider.enabled = false;
        }
        else
            swordCollider.enabled = true;

        _animator.SetInteger("MeleeAttackState", noOfClick);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Walk Run Blend") && noOfClick == 3)
        {
            noOfClick = 0;
        }
        if (Time.time - lastClickedTime >= maxComboDelay)
        {
            noOfClick = 0;
        }
        if (Time.time - lastClickedTime > coolDownTime)
            if (_starterAssetsInputs.attack && !_starterAssetsInputs.aiming && (noOfClick == 0 || _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75f))
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
