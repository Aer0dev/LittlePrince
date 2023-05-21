using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{

    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField]
    Transform lNoteAppear = null;

    [SerializeField]
    Transform rNoteAppear = null;

    [SerializeField]
    GameObject lNote = null;

    [SerializeField]
    GameObject rNote = null;


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime>=60d / bpm)
        {
            GameObject l_note = Instantiate(lNote, lNoteAppear.position, Quaternion.identity);
            GameObject r_note = Instantiate(rNote, rNoteAppear.position, Quaternion.identity);
            currentTime -= 60d / bpm;
        }
    }
}
