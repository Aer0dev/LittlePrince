using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hsbLeftNote : MonoBehaviour
{
    Stopwatch stopwatch;
    public GameObject Left;
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

        transform.Translate(Vector3.up * noteSpeed * Time.smoothDeltaTime);


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit") && Input.GetKey(KeyCode.A))
        {
            stopwatch.Stop();
            Destroy(Left);
            UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Hit"))
        {
            Left.SetActive(false);
            Destroy(Left);
            UnityEngine.Debug.Log("½ÇÆÐ");
        }
    }

}
