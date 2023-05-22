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
        
    }

     void Update()
    {
        if (Button_OnClick.PlanetFadeOut == true)
        {
        Switch = Mathf.Lerp(Switch, 1, 10.0f * Time.deltaTime);
        anim.SetFloat("Switch", Switch);
        anim.Play("FadeOutSwitch");
    }

        }

}
