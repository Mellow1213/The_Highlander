using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float HP;
    [SerializeField] private float CurrentHP;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    public void Damaged(float damage)
    {
        CurrentHP -= damage;
    }
    void Dead()
    {
        if(CurrentHP <= 0)
        {
            //»ç¸Á ¸ð¼Ç
            Destroy(gameObject);
        }
    }
}
