using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            theTimingManager.CheckTiming();
            //Debug.Log(GameManager.instance.count-140);
        }
    }
}
