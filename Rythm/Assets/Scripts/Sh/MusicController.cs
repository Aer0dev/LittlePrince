using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController: MonoBehaviour
{
    public AudioSource audioSource;
    public double startTime;
    public double delayInSeconds = 3.0;     // 음악 3초 뒤에 시작하도록
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startTime = AudioSettings.dspTime;
        audioSource.PlayScheduled(startTime + delayInSeconds);
    }

   /* void Update()
    {
        double currentTime = AudioSettings.dspTime - startTime;
        if (currentTime >= songLength)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
   */
}
