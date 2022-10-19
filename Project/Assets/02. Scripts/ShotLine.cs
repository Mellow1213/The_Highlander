using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLine : MonoBehaviour
{
    public GameObject muzzle;
    LineRenderer _lineRenderer;
    ThirdPersonShooterController _thirdPersonShooterController;
    // Start is called before the first frame update
    void Start()
    {
        _thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        linePos[0] = muzzle.transform.position;
        linePos[2] = _thirdPersonShooterController.aimDirection;
        linePos[1] = (linePos[0] + linePos[2]) * 0.5f;
        */
        _lineRenderer.SetPosition(0, muzzle.transform.position);
        _lineRenderer.SetPosition(2, _thirdPersonShooterController.mouseWorldPosition);
        _lineRenderer.SetPosition(1, 0.5f * (muzzle.transform.position + _thirdPersonShooterController.mouseWorldPosition));
    }
}
