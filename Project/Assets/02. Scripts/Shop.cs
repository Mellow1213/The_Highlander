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
    SphereCollider sphereCollider;
    bool isRun = false;
    bool allowedShow = false;
    bool isShowing = false;
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        _input = player.GetComponent<StarterAssetsInputs>();
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
        isShowing = true;
        uiGroup.DOAnchorPos(Vector3.zero, 1f).SetEase(Ease.OutCubic);// = Vector3.zero;
    }

    public void HideUI()
    {
        isShowing = false;
        uiGroup.DOAnchorPos(Vector3.down * 1000, 1f).SetEase(Ease.OutCubic); 
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

    }
    public void PlusHealth()
    {
    }

    public void PlusFireDamage()
    {

    }
    public void PlusSwordDamage()
    {

    }
}
