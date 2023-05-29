using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hsbRightNote : MonoBehaviour
{
    Stopwatch stopwatch;
    public GameObject Right;
    public float noteSpeed = 1f;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }


    

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    void Update()
    {

        transform.Translate(Vector3.down * noteSpeed * Time.smoothDeltaTime);


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit") && Input.GetKey(KeyCode.D))
        {

            stopwatch.Stop();
            Destroy(Right);
            UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit"))
        {

            Right.SetActive(false);
            Destroy(Right);
            UnityEngine.Debug.Log("½ÇÆÐ");
        }
    }

}


