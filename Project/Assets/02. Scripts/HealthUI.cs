using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    Health _health;
    public Color startColor;
    public Color endColor;
    // Start is called before the first frame update
    void Start()
    {
        _health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = _health.getHealthPercent();
        healthBar.color = Color.Lerp(endColor, startColor, _health.getHealthPercent());
        
        healthText.text = _health.health.ToString();
        healthText.color = Color.Lerp(endColor, startColor, _health.getHealthPercent());

    }
}
