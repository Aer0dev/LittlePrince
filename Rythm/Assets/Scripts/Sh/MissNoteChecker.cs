using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissNoteChecker : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip MissSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Debug.Log("Miss");
            audioSource.PlayOneShot(MissSound);
        }
    }
 
}
