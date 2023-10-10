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


    void Update()       //�÷��̾�� ������Ʈ�� �Ÿ� ����� ���� �Ÿ� ������ ������Ʈ �̸��� ���
    {


        Dist = Vector2.Distance(Player.transform.position, Object.transform.position);

        if (Dist < 6f)      //�Ÿ� 6 ���� ����
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
