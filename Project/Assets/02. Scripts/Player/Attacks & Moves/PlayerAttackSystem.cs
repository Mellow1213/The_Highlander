using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class PlayerAttackSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;

    public GameObject barrier;
    public GameObject spawnPos;
    public float barrierCost;

    public Image barrierImage;


    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        Barrier();
    }
    void Barrier()
    {
        if (_input.weapon)
        {
            _input.weapon = false;
            if(GameManager.Instance.barrierAmount > 0 && GameManager.Instance.Energy >= barrierCost + GameManager.Instance.minusBarrierCost)
            {
                Instantiate(barrier, spawnPos.transform.position, barrier.transform.rotation);
                GameManager.Instance.barrierAmount--;
                GameManager.Instance.Energy -= barrierCost + GameManager.Instance.minusBarrierCost;
            }
        }
        barrierImage.fillAmount = GameManager.Instance.Energy / (barrierCost + GameManager.Instance.minusBarrierCost);
    }
}
