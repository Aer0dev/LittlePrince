using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteFade : MonoBehaviour
{
    protected GameObject FadeType;
    public Image image;
    public static bool FadeOff = false;


    protected void Init()
    {
        if (GameObject.Find("Canvas/FadeOut") != null)
            FadeType = GameObject.Find("Canvas/FadeOut");
        else if (GameObject.Find("Canvas/FadeIn") != null)
            FadeType = GameObject.Find("Canvas/FadeIn");
        else
        {
            Debug.Log("Check FadeIn Or FadeOut");
            return;
        }
        FadeType.transform.SetAsLastSibling();
    }


    protected void Faded()
    {
        if (GameObject.Find("Canvas/FadeOut") != null)
            StartCoroutine(FadeOutCoroutine());
        else if (GameObject.Find("Canvas/FadeIn") != null)
            StartCoroutine(FadeInCoroutine());
        else
        {
            Debug.Log("Check Faded");
            return;
        }
    }


    protected IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 0;

        while (fadeCount <= 1.0f)
        {
            fadeCount += 0.005f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        FadeOff = true;
    }


    protected IEnumerator FadeInCoroutine()
    {
        float fadeCount = 1;

        while (fadeCount >= 0f)
        {
            fadeCount -= 0.005f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        FadeOff = true;
    }




}
