using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public Animator anim;
    float Switch = 0.5f;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        Button_OnClick.PlanetFadeOut = false;
        
    }

     void Update()
    {
        if (Button_OnClick.PlanetFadeOut == true)   //title俊辑 家青己 牧飘费
        {
        Switch = Mathf.Lerp(Switch, 1, 10.0f * Time.deltaTime);
        anim.SetFloat("Switch", Switch);
        anim.Play("FadeOutSwitch");
    }

        }

}
