using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hsbLeftNote : MonoBehaviour
{
    Stopwatch stopwatch;
    public GameObject Left;
    public GameObject Effect;
    public float noteSpeed = 4f;
    private bool check = false;
    private hsbScoreManager scoreManager;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        scoreManager = FindObjectOfType<hsbScoreManager>();
    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    void Update()
    {

        transform.Translate(Vector3.up * noteSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.A))
        {
            if(check)
            {
                stopwatch.Stop();
                scoreManager.score += 100;
                GameObject effect = Instantiate(Effect, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.4f, transform.position.z), Quaternion.identity);
                Destroy(effect, 0.1f);
                Destroy(Left);
                
                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit"))
            check = true;

        if (collision.CompareTag("Left"))
        {
            check = false;
            Destroy(Left);
            UnityEngine.Debug.Log("½ÇÆÐ");
        }

    }

}
