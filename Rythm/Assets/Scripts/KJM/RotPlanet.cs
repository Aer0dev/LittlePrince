using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPlanet : MonoBehaviour
{
    public GameObject planet;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            speed+=0.1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed -= 0.1f;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, speed);
    }
}
