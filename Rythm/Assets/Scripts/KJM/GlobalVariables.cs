using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    private static GlobalVariables instance;
    public int testVariable=10;     //삭제되지 않는 value

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


    public static GlobalVariables Instance      //사라지지 않는 instance
    {
        get { return instance; }
    }


}
