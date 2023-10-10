using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    private static GlobalVariables instance;
    public int testVariable=10;     //�������� �ʴ� value

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static GlobalVariables Instance      //������� �ʴ� instance
    {
        get { return instance; }
    }


}
