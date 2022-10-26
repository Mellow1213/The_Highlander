using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimingSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransfrom;

    public GameObject bulletPrefab;
    private StarterAssetsInputs _starterAssetsInputs;
    private ThirdPersonController _thirdPersonController;
    public Vector3 aimDirection;
    public Vector3 mouseWorldPosition = Vector3.zero;

    Health _health;

    private Animator _animator;
    private LineRenderer _lineRenderer;    //ÃÑ¾Ë ±ËÀû »ý¼º ¶óÀÎ ·»´õ·¯

    // ÃÑ ¹ß»ç °£°Ý(µô·¹ÀÌ) °ü·Ã º¯¼ö
    public float fireDelay = 0.3f;
    [SerializeField] private float fireTimer = 0f;
    public GameObject Sword;
    public GameObject Gun;
    public bool AimAllowed = true;
    public bool doAim;
    Transform t;
    private void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        if (_animator)
            t = _animator.GetBoneTransform(HumanBodyBones.Spine);
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransfrom.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            aimDirection = (worldAimTarget - transform.position).normalized;
            hitTransform = raycastHit.transform;
        }

        if (_starterAssetsInputs.aiming && AimAllowed && _thirdPersonController.Grounded && !_thirdPersonController._isDodging && !_health.isDeath) 
        {
            doAim = true;
        }
        else
        {
            doAim = false;
        }

        if (doAim)
        {
            debugTransfrom.gameObject.SetActive(true);
            _animator.SetBool("isAiming", doAim);
            Gun.SetActive(true);
            Sword.SetActive(false);
        }
        else
        {
            debugTransfrom.gameObject.SetActive(false);
            _animator.SetBool("isAiming", false);
            Gun.SetActive(false);
            Sword.SetActive(true);
        }

        if (doAim && _animator.GetCurrentAnimatorStateInfo(0).IsTag("CanAim"))
        {

            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensitivity(aimingSensitivity);
            _thirdPersonController.SetRotateOnMove(false);
            _thirdPersonController.JumpAllowed = false;
            _thirdPersonController.DodgeAllowed = false;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            _thirdPersonController.SetRotateOnMove(true);
            _aimVirtualCamera.gameObject.SetActive(false);
            _thirdPersonController.SetSensitivity(normalSensitivity);
            _thirdPersonController.JumpAllowed = true;
            _thirdPersonController.DodgeAllowed = true;
        }

        if (_starterAssetsInputs.attack && doAim && fireTimer >= fireDelay)
        {
            StartCoroutine(CreateShotLine());
            if (hitTransform != null)
            {
                Instantiate(bulletPrefab, raycastHit.point, Quaternion.identity);
                if (hitTransform.CompareTag("Enemy"))
                {
                    hitTransform.GetComponent<EnemyHit>().Damaged(1.5f);
                }
                else
                    Debug.Log("¹Ù´Ú ¸íÁß!");
            }
        }
        if (fireTimer < fireDelay)
            fireTimer += Time.deltaTime;
    }
    public Vector3 chestOffset;
    public GameObject firepos;

    private void LateUpdate()
    {
        if (doAim)
        {
            t.LookAt(debugTransfrom);
            t.rotation = t.rotation * Quaternion.Euler(chestOffset);
        }
    }
    IEnumerator CreateShotLine()
    {
        _lineRenderer.enabled = true;
        fireTimer = 0f;
        yield return new WaitForSeconds(0.03f);
        _lineRenderer.enabled = false;
    }
}
