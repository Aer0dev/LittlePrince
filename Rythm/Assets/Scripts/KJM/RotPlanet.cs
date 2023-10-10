using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RotPlanet : MonoBehaviour
{
    public GameObject planet;
    public float speed;

    public TalkManager tmanager;

    public Animator anim;
    public GameObject player;
    private bool movement = false;
    private float Switch = 0f;
    Vector2 _dir=new Vector2(0.2f,0.2f);

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()       //a, d 로 이동 && 행성 이동
    {
        
        //planet rotation
        if (Input.GetKey(KeyCode.D)&&!tmanager.isAction)
        {
            speed+=0.3f;
            _dir=new Vector2(0.2f,0.2f);
            movement = true;
        }
        else if (Input.GetKey(KeyCode.A) && !tmanager.isAction)
        {
            speed -= 0.3f;
            _dir= new Vector2(-0.2f, 0.2f);
            movement = true;
        }
        else
            movement = false;

        //player anim
        if(movement)
        {
            Switch = Mathf.Lerp(Switch, 1, 10.0f * Time.deltaTime);
            anim.SetFloat("Blend", Switch);
            anim.Play("IdleWalk");
        }
        else
        {
            Switch = Mathf.Lerp(Switch, 0, 10.0f * Time.deltaTime);
            anim.SetFloat("Blend", Switch);
            anim.Play("IdleWalk");
        }





        player.transform.localScale = _dir;
       planet.transform.rotation = Quaternion.Euler(0f, 0f, speed);

    }
}
