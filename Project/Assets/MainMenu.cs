using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject[] poses;
    public GameObject panel;
    Image image;

    bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        image = panel.GetComponent<Image>();
        image.DOColor(new Color(0, 0, 0, 0), 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            StartCoroutine(View());
        }
    }

    IEnumerator View()
    {
        isRunning = true;
        yield return new WaitForSeconds(5f);
        for (int i = 1; i<poses.Length; i++)
        {
            image.DOColor(new Color(0, 0, 0, 1), 1.5f);
            Debug.Log("1");
            yield return new WaitForSeconds(1.5f);
            poses[i].SetActive(true);
            Debug.Log("2");
            yield return new WaitForSeconds(0.3f);
            image.DOColor(new Color(0, 0, 0, 0), 0.5f);
            yield return new WaitForSeconds(5f);
            Debug.Log("3");
        }
        image.DOColor(new Color(0, 0, 0, 1), 1.5f);
        yield return new WaitForSeconds(1.5f);
        for (int i = 1; i<poses.Length; i++)
        {
            poses[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.3f);
        image.DOColor(new Color(0, 0, 0, 0), 0.5f);
        isRunning = false;
    }

}
