using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rigid;
    public TalkManager manager;
    Vector3 dirVec;
    GameObject scanObject;
    void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player.transform.localScale.x > 0)
            dirVec = Vector3.right;
        else if(Player.transform.localScale.x < 0)
            dirVec=Vector3.left;

        if(Input.GetButtonDown("Jump")&&scanObject!=null)   //player 가 space 누르면 앞에 있는 오브젝트 인식
        {
            manager.Action(scanObject);
           //Debug.Log(scanObject.name);
        }

    }

    void FixedUpdate()
    {
        //ray               raycast 로 player 앞의 오브젝트 인식
        Debug.DrawRay(Player.transform.position+new Vector3(0f,1f,0), dirVec*1f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }


}
