using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerAttackSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;

    public GameObject barrier;
    public GameObject spawnPos;
    public float barrierCost;

    public Image barrierImage;

    public TextMeshProUGUI Energy;
    public TextMeshProUGUI barrierText;


    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        Energy.text = GameManager.Instance.Energy.ToString();
        Barrier();
        Skill();
        Ultimate();
    }
    void Barrier()
    {
        barrierText.text = GameManager.Instance.barrierAmount.ToString();
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

    public float skillCoolTime;
    float skillTimer = 30f;
    public float skillCost;
    public GameObject skill;
    public Image skillImage;
    public TextMeshProUGUI skillText;
    float skillTimeShow;
    void Skill()
    {
        skillTimer += Time.deltaTime;
        skillTimeShow = (float)(Math.Truncate((skillCoolTime - skillTimer) * 10) / 10);
        skillTimeShow = Mathf.Clamp(skillTimeShow, 0, 999);
        skillText.text = skillTimeShow + "s";
        if (_input.skill)
        {
            _input.skill = false;
            if (GameManager.Instance.Energy >= skillCost + GameManager.Instance.minusSkillCost && skillTimer > skillCoolTime)
            {
                GameObject temp = Instantiate(skill, spawnPos.transform.position, skill.transform.rotation);
                temp.transform.parent = null;
                skillTimer = 0f;
                GameManager.Instance.Energy -= skillCost + GameManager.Instance.minusSkillCost;
            }
        }
        skillImage.fillAmount = GameManager.Instance.Energy / (skillCost + GameManager.Instance.minusSkillCost);
    }

    public float UCoolTime;
    float UTimer = 60f;
    public float UCost;
    public GameObject U;
    public Image UImage;
    public TextMeshProUGUI UText;
    float UTimeShow;
    void Ultimate()
    {
        UTimer += Time.deltaTime;
        UTimeShow = (float)Math.Truncate((UCoolTime - UTimer) * 10) / 10;
        UTimeShow = Mathf.Clamp(UTimeShow, 0, 999);
        UText.text = UTimeShow + "s";
        if (_input.ultimate)
        {
            _input.ultimate = false;
            if (GameManager.Instance.Energy >= UCost + GameManager.Instance.minusUltimateCost && UTimer > UCoolTime)
            {
                GameObject temp = Instantiate(U, spawnPos.transform.position, U.transform.rotation);
                temp.transform.parent = null;
                UTimer = 0f;
                GameManager.Instance.Energy -= UCost + GameManager.Instance.minusUltimateCost;
            }
        }
        UImage.fillAmount = GameManager.Instance.Energy / (skillCost + GameManager.Instance.minusUltimateCost);
    }
}
