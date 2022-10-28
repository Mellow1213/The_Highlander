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
    public Color color;
    public Color color_fadeOut;
    public Renderer background;
    bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        image = panel.GetComponent<Image>();
        image.DOColor(color_fadeOut, 2f);
    }
    float offset;
    // Update is called once per frame
    void Update()
    {
        offset = Time.time;
        //background.material.SetTextureOffset(, new Vector2(offset, 0));
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
            image.DOColor(color, 1.5f);
            Debug.Log("1");
            yield return new WaitForSeconds(1.5f);
            poses[i].SetActive(true);
            Debug.Log("2");
            yield return new WaitForSeconds(1f);
            image.DOColor(color_fadeOut, 2f);
            yield return new WaitForSeconds(5f);
            Debug.Log("3");
        }
        image.DOColor(color, 1.5f);
        yield return new WaitForSeconds(1.5f);
        for (int i = 1; i<poses.Length; i++)
        {
            poses[i].SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        image.DOColor(color_fadeOut, 2f);
        isRunning = false;
    }

}
