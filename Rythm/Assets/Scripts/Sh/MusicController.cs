using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicController: MonoBehaviour
{
    public AudioSource audioSource;
    public double startTime;
    public double delayInSeconds = 0.99;     // ~초 후에 음악 시작
    public Slider musicSlider;                              // 슬라이더 
    private double musicLength;                         // 음악길이


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startTime = AudioSettings.dspTime;
        audioSource.PlayScheduled(startTime + delayInSeconds);

        musicLength = audioSource.clip.length;       // 음악길이 = 음악길이 + 지연시작시간
        musicSlider.value = 0;                                                 // 초기화
        musicSlider.minValue = 0;
        musicSlider.maxValue = (float)musicLength;       // 최대값 설정
        
    }

   void Update()
    {
        double currentTime = AudioSettings.dspTime - (startTime + delayInSeconds);
        musicSlider.value = (float)currentTime;
    }
}
