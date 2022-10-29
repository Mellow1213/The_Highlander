using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShieldScript : MonoBehaviour
{
    public MeshRenderer _meshRenderer1;
    public MeshRenderer _meshRenderer2;
    public GameObject barrier;

    public float barrierTime;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > barrierTime + GameManager.Instance.plusBarrierTime)
        {
            _meshRenderer2.material.DOColor(new Color(0,0,0,0), 2f);
            if (timer > barrierTime + GameManager.Instance.plusBarrierTime + 2f)
                Destroy(gameObject);
        }
    }


    IEnumerator Spawning()
    {
        _meshRenderer1.material.DOFloat(1, "Vector1_CFBBCBA", 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);
        barrier.SetActive(true);
        _meshRenderer1.material.DOFloat(-5, "Vector1_CFBBCBA", 1f).SetEase(Ease.Linear);
    }
}
