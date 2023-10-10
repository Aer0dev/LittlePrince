using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControl : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isCheck", true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isCheck", false);
        }    
    }
}
