using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnParticle : MonoBehaviour
{
    public VisualEffect magicBall;
    public VisualEffect Snow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        magicBall.pause = true;
    }
}
