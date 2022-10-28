using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    public int gold = 0;

    public float plusSwordDamage = 0f;
    public float plusFireDamage = 0f;
    public float minusFireRate = 0f;
    public float plusHealth = 0f;
    public float speed = 0f;


    public float barrierAmount = 0f;
    public float plusBarrierHealth = 0f;
    public float minusBarrierCost = 0f;
    public float minusUltimateCost = 0f;
    public float minusDodgeCoolTime = 0f;
}
