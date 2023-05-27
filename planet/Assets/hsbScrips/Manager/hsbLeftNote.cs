using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hsbLeftNote : MonoBehaviour
{
    hsbReader delete;
    Stopwatch stopwatch;
    public GameObject Left;
    public float noteSpeed = 1f;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hit"))
        {
            Left.SetActive(false);
            Destroy(Left);
            UnityEngine.Debug.Log("½ÇÆÐ");
        }
    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            stopwatch.Stop();
            Destroy(Left);
            UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
        }

        transform.Translate(Vector3.up * noteSpeed * Time.smoothDeltaTime);


    }

}
