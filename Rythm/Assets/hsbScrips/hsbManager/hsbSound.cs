using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// 배경 사운드 및 UI 컨트롤 스크립트
public class hsbSound : MonoBehaviour
{
    public AudioSource audioSource;

    public double startTime;

    public double delayInSeconds = 3.0;     // 음악 실행 딜레이 변수

    public TextMeshProUGUI gameClear; // 게임 클리어 오브젝트
    public TextMeshProUGUI gameOver; // 게임 오버 오브젝트
    private hsbScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<hsbScoreManager>();
        audioSource = GetComponent<AudioSource>();
        startTime = AudioSettings.dspTime;
        audioSource.PlayScheduled(startTime + delayInSeconds); // 음악 시작
        startGame();
    }

    private void Update()
    {
        if(!audioSource.isPlaying) // 음악이 플레이되지 않을 때 게임 종료
            gameEnd();
    }

    // 게임 시작 함수
    void startGame()
    {
        gameClear.gameObject.SetActive(false); // 게임 클리어 오브젝트 비활성화
        gameOver.gameObject.SetActive(false); // 게임 오버 오브젝트 비활성화
    }

    // 게임 종료 함수
    void gameEnd()
    {

        // 점수가 25000 점 이상일 경우 게임 클리어
            if (scoreManager.score >= 25000)
            {
                gameClear.gameObject.SetActive(true);
            SceneManager.LoadScene("KJM_Map");

        }

        // 점수가 25000 미만일 경우 게임 오버
        else
            {
                gameOver.gameObject.SetActive(true);
            SceneManager.LoadScene("KJM_Map");
        }


    }
}
