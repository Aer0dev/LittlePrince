using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public  AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       audioSource.Play();
        
    }


}