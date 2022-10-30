using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;

    Animator _animator;

    public bool isInvade = false;
    public bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        Death();
    }

    float timer = 0f;
    public GameObject txt;
    void Death()
    {
        if (health <= 0 && !isDeath)
        {
            isDeath = true;
            _animator.SetTrigger("Death");
            timer += Time.deltaTime;
            txt.SetActive(true);
            if (timer > 4f)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }   

    public float getHealthPercent()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        return health / maxHealth;
    }

    public void Damaged(float damage)
    {
        if(!isInvade)
            health -= damage;
    }

    // Call in Death Animation Event
    public void DeathEffect()
    {
        Debug.Log("ªÁ∏¡ ¿Ã∆Â∆Æ √‚∑¬");
    }
}
