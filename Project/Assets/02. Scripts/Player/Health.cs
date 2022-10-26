using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 10f;

    Animator _animator;

    public bool isInvade = false;
    public bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void Death()
    {
        if (health <= 0 && !isDeath)
        {
            isDeath = true;
            _animator.SetTrigger("Death");
        }
    }   

    public void Damaged(float damage)
    {
        if(!isInvade)
            health -= damage;
    }

    // Call in Death Animation Event
    public void DeathEffect()
    {
        Debug.Log("»ç¸Á ÀÌÆåÆ® Ãâ·Â");
    }
}
