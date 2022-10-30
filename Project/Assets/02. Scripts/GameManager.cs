using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if(null == instance )
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
            if (null == instance)
                return null;
            return instance;
        }
    }

    public int gold = 0;

    public float plusSwordDamage = 0f;
    public float plusFireDamage = 0f;
    public float minusFireRate;
    public float plusHealth = 0f;


    public float speed = 0f;
    public float minusDodgeCoolTime = 0f;

    public int barrierAmount = 0;
    public float plusBarrierTime = 0f;
    public float minusBarrierCost = 0f;
    public float minusSkillCost = 0f;
    public float minusUltimateCost = 0f;

    public float Energy = 0f;

}
