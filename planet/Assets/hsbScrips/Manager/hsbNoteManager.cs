using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hsbNoteManager : MonoBehaviour
{

    Stopwatch stopwatch;
    public GameObject GO;
    public float noteSpeed = 1f;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
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

        transform.Translate(Vector3.up* noteSpeed * Time.smoothDeltaTime);
        {
            GO.SetActive(false);
            Destroy(GO);
            UnityEngine.Debug.Log("½ÇÆÐ");
        }
    }
}
