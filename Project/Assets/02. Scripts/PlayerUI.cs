using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using DG.Tweening;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public RectTransform toolTip;
    Vector2 statusShow = new Vector2(-745, 170);
    Vector2 statusHide = new Vector2(-1200, 170);
    public TextMeshProUGUI toolTipText;

    public RectTransform status;
    Vector2 toolTipShow = new Vector2(770, 100);
    Vector2 toolTipHide= new Vector2(1150, 100);
    public TextMeshProUGUI statusText;

    StarterAssetsInputs _input;

    string tooltip = "";

    Health _health;
    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _health = GetComponent<Health>();
    }
    bool on = false;
    private void Update()
    {
        if (_input.status)
        {
            status.DOAnchorPos(statusShow, 1f).SetEase(Ease.OutCubic);
            statusText.text = "Max Health " + _health.maxHealth +"\nSword Damage "+ (4+GameManager.Instance.plusSwordDamage) +"\nFire Damage " + (1+GameManager.Instance.plusFireDamage) +"\nFire Rate "+(0.1 * GameManager.Instance.minusFireRate) +"s\nRun Speed "+ (5.335 + GameManager.Instance.speed) + "\n" +
                "Dodge CoolTime "+(4-GameManager.Instance.minusDodgeCoolTime) +"s\nBarrier Time\nE Skill Cost\nQ Skill Cost";
        }
        else
        {
            status.DOAnchorPos(statusHide, 1f).SetEase(Ease.OutCubic);
        }

        if (on)
        {
            toolTip.DOAnchorPos(toolTipShow, 1f).SetEase(Ease.OutCubic);
            toolTipText.text = tooltip;
        }
        else
        {
            toolTip.DOAnchorPos(toolTipHide, 1f).SetEase(Ease.OutCubic);
        }
    }

    public void setToolTipText (string txt)
    {
        on = true;
        tooltip = txt;
    }
    public void setOff()
    {
        on = false;
    }
}
