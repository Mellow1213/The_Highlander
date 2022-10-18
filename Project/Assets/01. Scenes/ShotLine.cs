using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLine : MonoBehaviour
{
    public GameObject[] linePosObject;
    Vector3[] linePos;
    LineRenderer _lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, linePosObject[0].transform.position);
        _lineRenderer.SetPosition(1, linePosObject[1].transform.position);
        _lineRenderer.SetPosition(2, linePosObject[2].transform.position);
    }
}
