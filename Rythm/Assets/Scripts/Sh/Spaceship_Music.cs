using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Music : MonoBehaviour
{
    public AudioSource audioSoruce;

    private double startTime;

    public double delayInSeconds = 3.0;     // 음악 3초 뒤에 시작하도록
    
    // Start is called before the first frame update
    void Start()
    {
        audioSoruce = GetComponent<AudioSource>();
        startTime = AudioSettings.dspTime;
        audioSoruce.PlayScheduled(startTime + delayInSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
