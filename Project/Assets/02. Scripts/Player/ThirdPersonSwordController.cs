using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ThirdPersonSwordController : MonoBehaviour
{
    private Animator _animator;
    private StarterAssetsInputs _starterAssetsInputs;
    public float coolDownTime = 2f;
    [SerializeField] private float nextFireTime = 0f;
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
        if (noOfClick == 0)
        {
            swordCollider.enabled = false;
        }
        else
            swordCollider.enabled = true;
        _animator.SetInteger("MeleeAttackState", noOfClick);
        if(noOfClick >= 3)
        {
            noOfClick = 0;
        }
        if(Time.time - lastClickedTime >= maxComboDelay)
        {
            noOfClick = 0;
        }
        if(Time.time-lastClickedTime > coolDownTime)
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
        if(noOfClick == 1)
        {
            Debug.Log("콤보1 공격");
        }
        noOfClick = Mathf.Clamp(noOfClick, 0, 3);

        if(noOfClick == 2)
        {
            Debug.Log("콤보2 공격");
        }
        if (noOfClick == 3)
        {
            Debug.Log("콤보3 공격");
        }
    }
}
