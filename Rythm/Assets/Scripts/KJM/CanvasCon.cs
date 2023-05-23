using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasCon : SpriteFade
{



    private void Update()
    {
        if (FadeOff)
        {
            Debug.Log("In");
            gameObject.SetActive(false);
            FadeOff = false;
        }
    }



    void Start()
    {
        Init();
        Faded();
    }


}
