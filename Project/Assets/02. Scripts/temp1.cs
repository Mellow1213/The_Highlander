using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp1 : MonoBehaviour
{
    float scrollSpeed = 0.02f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}