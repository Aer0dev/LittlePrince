using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hsbRightNote : MonoBehaviour
{
    Stopwatch stopwatch;
    public GameObject Right;
    public float noteSpeed = 1f;
    private bool check;
    public GameObject Effect;
    private hsbScoreManager scoreM;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        scoreM = FindObjectOfType<hsbScoreManager>();
    }


    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    void Update()
    {

        transform.Translate(Vector3.down * noteSpeed * Time.smoothDeltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (check)
            {
                stopwatch.Stop();
                scoreM.score += 100;
                GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
                Destroy(effect, 0.1f);
                Destroy(Right);

                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit"))
            check = true;

        if (collision.CompareTag("Right"))
        {
            check = false;
            Destroy(Right);
            UnityEngine.Debug.Log("½ÇÆÐ");
        }

    }

}


