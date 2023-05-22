using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Music : MonoBehaviour
{
    private AudioSource audioSource;

    private double startTime;

    public double delayInSeconds = 3.0;     // 음악 3초 뒤에 시작하도록

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = false;
        startTime = AudioSettings.dspTime;
        audioSource.PlayScheduled(startTime + delayInSeconds);
    }
}
