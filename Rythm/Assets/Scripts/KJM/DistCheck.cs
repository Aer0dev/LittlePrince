using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistCheck : MonoBehaviour
{
    public GameObject _Text;
    public Canvas canvas;


    public GameObject Player;
    public GameObject Object;
    private float Dist;
    private bool Access = false;
    private bool TextAccess = true;
    void Start()
    {

    }


    void Update()       //플레이어와 오브젝트의 거리 계산후 일정 거리 들어오면 오브젝트 이름을 출력
    {


        Dist = Vector2.Distance(Player.transform.position, Object.transform.position);

        if (Dist < 6f)      //거리 6 이하 계산시
            Access = true;
        else
        {
            Access = false;
            TextAccess = true;
        }

        if (Access == true && Object.gameObject.name == Object.name && TextAccess == true)
        {
            GameObject spawnedObject = Instantiate(_Text, canvas.transform);
            Destroy(spawnedObject,5.0f);


            //Debug.Log(Object.name);
            TextAccess = false;
        }

    }



}
