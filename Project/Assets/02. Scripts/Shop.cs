using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using DG.Tweening;
public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;
    StarterAssetsInputs _input;
    GameObject player;
    bool allowedShow = false;
    public bool isShowing = false;
    Health health;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _input = player.GetComponent<StarterAssetsInputs>();
        health = player.GetComponent<Health>();
    }

    private void Update()
    {
        if (_input.interaction && allowedShow)
        {
            _input.interaction = false;
            if (isShowing)
            {
                HideUI();
            }
            else
            {
                ShowUI();
            }
        }
    }

    public void ShowUI()
    {
        Cursor.visible = true;
        _input.cursorInputForLook = false;
        _input.cursorLocked = false;
        isShowing = true;
        uiGroup.DOAnchorPos(Vector3.zero, 1f).SetEase(Ease.OutCubic);// = Vector3.zero;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void HideUI()
    {
        Cursor.visible = false;
        _input.cursorInputForLook = true;
        _input.cursorLocked = true;
        isShowing = false;
        uiGroup.DOAnchorPos(Vector3.down * 1000, 1f).SetEase(Ease.OutCubic);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowedShow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowedShow = false;
            if (isShowing)
                HideUI();
        }
    }

    public void Heal()
    {
        if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.gold -= 100;
            health.health += 5f;
        }
    }
    public void PlusHealth()
    {
        if (GameManager.Instance.gold >= 1000)
        {
            GameManager.Instance.gold -= 1000;
            health.maxHealth += 5;
            health.health += 5;
        }
    }

    public void PlusFireDamage()
    {
        if (GameManager.Instance.gold >= 1200)
        {
            GameManager.Instance.gold -= 1200;
            GameManager.Instance.plusFireDamage += 0.5f;
        }
    }
    public void MinusFireDelay()
    {
        if (GameManager.Instance.gold >= 2000)
        {
            GameManager.Instance.gold -= 2000;
            GameManager.Instance.minusFireRate *= 0.9f;
        }
    }
    public void PlusSwordDamage()
    {
        if (GameManager.Instance.gold >= 1500)
        {
            GameManager.Instance.gold -= 1500;
            GameManager.Instance.plusSwordDamage += 1;
        }
    }
    public void PlusRunSpeed()
    {
        if (GameManager.Instance.gold >= 3000)
        {
            GameManager.Instance.gold -= 3000;
            GameManager.Instance.speed += 0.5f;
        }
    }

    public void MinusDodgeCoolTime()
    {
        if (GameManager.Instance.gold >= 4000)
        {
            GameManager.Instance.gold -= 4000;
            GameManager.Instance.minusDodgeCoolTime += 0.1f;
        }
    }

    public void BarrierAmount()
    {
        if (GameManager.Instance.gold >= 1000)
        {
            GameManager.Instance.gold -= 1000;
            GameManager.Instance.barrierAmount += 1;
        }
    }

    public void BarrierTime()
    {
        if (GameManager.Instance.gold >= 1500)
        {
            GameManager.Instance.gold -= 1500;
            GameManager.Instance.plusBarrierTime += 0.5f;
        }
    }

    public void SkillCost()
    {
        if (GameManager.Instance.gold >= 3000)
        {
            GameManager.Instance.gold -= 3000;
            GameManager.Instance.minusSkillCost -= 5f;
        }

    }

    public void UltimateCost()
    {
        if(GameManager.Instance.gold >= 4500)
        {
            GameManager.Instance.gold -= 4500;
            GameManager.Instance.minusUltimateCost -= 3f;
        }
    }
}
