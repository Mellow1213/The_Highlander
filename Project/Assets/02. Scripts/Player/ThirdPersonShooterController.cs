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

    private StarterAssetsInputs _starterAssetsInputs;
    private ThirdPersonController _thirdPersonController;
    public Vector3 aimDirection;

    private void Awake()    
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

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


        if (_starterAssetsInputs.aiming)
        {
            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensitivity(aimingSensitivity);
            _thirdPersonController.SetRotateOnMove(false);


            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            _thirdPersonController.SetRotateOnMove(true);
            _aimVirtualCamera.gameObject.SetActive(false);
            _thirdPersonController.SetSensitivity(normalSensitivity);
        }

        if(_starterAssetsInputs.attack && _starterAssetsInputs.aiming)
        {
            if(hitTransform != null)
            {
                if (hitTransform.CompareTag("Enemy"))
                    hitTransform.GetComponent<EnemyHit>().Damaged(3);
                else
                    Debug.Log("¹Ù´Ú ¸íÁß!");
            }
        }
    }
}
