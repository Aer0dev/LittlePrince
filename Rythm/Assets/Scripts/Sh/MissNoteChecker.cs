using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissNoteChecker : MonoBehaviour
{
    public GameObject Accuracy;
    public AudioSource audioSource;
    public AudioClip MissSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Accuracy = GameObject.Find("Accuracy");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Debug.Log("Miss");
            Accuracy.GetComponent<Accuracy_Check>().IncreaseMissedNote();
            audioSource.PlayOneShot(MissSound);
        }
    }
 
}
