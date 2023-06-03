using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hsbSound : MonoBehaviour
{
    public AudioSource audioSource;

    public double startTime;

    public double delayInSeconds = 3.0;     // 음악 3초 뒤에 시작하도록

    public TextMeshProUGUI gameClear;
    public TextMeshProUGUI gameOver;
    private hsbScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<hsbScoreManager>();
        audioSource = GetComponent<AudioSource>();
        startTime = AudioSettings.dspTime;
        audioSource.PlayScheduled(startTime + delayInSeconds);

        startGame();
    }

    private void Update()
    {
        if(!audioSource.isPlaying)
            gameEnd();
    }

    void startGame()
    {
        gameClear.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    void gameEnd()
    {

            if (scoreManager.score >= 25000)
            {
                gameClear.gameObject.SetActive(true);
            }

            else
            {
                gameOver.gameObject.SetActive(true);
            }


    }
}
