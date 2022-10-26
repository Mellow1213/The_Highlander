using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorAction : MonoBehaviour
{
    public Vector3 openPos;
    public Vector3 closePos;

    public void Open()
    {
        transform.DOLocalMove(openPos, 1f);
    }
    public void Close()
    {
        transform.DOLocalMove(closePos, 1f);

    }
}
