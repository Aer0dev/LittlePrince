using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Note_Sh : MonoBehaviour
{
    public AudioSource audioSource;
    Stopwatch stopwatch;
    public GameObject GO;
    public float noteSpeed = 1f;        

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            stopwatch.Stop();
            Destroy(GO);
            UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
        }
    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }
 
    void Update()
    {
        transform.Translate(Vector3.back*noteSpeed*Time.smoothDeltaTime);
        {
            if (GO.transform.position.z <= -2)
            {
                GO.SetActive(false);
                UnityEngine.Debug.Log("½ÇÆÐ");
                 Destroy(GO);
            }
        }
    }
}
