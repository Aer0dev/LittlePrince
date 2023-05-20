using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoteCtrl : MonoBehaviour
{

    public float noteSpeed = 4f;
    GameObject Left;
    GameObject Right;
    // Start is called before the first frame update
    void Start()
    {
        Left = GameObject.FindWithTag("Left");
        Right = GameObject.FindWithTag("Right");
    }

    // Update is called once per frame
    void Update()
    {
        Left.transform.localPosition += Vector3.up * noteSpeed * Time.deltaTime;
        Right.transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }
}
