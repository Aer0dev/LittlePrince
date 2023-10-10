using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// ��� ���� �� UI ��Ʈ�� ��ũ��Ʈ
public class hsbSound : MonoBehaviour
{
    public AudioSource audioSource;

    public double startTime;

    public double delayInSeconds = 3.0;     // ���� ���� ������ ����

    public TextMeshProUGUI gameClear; // ���� Ŭ���� ������Ʈ
    public TextMeshProUGUI gameOver; // ���� ���� ������Ʈ
    private hsbScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<hsbScoreManager>();
        audioSource = GetComponent<AudioSource>();
        startTime = AudioSettings.dspTime;
        audioSource.PlayScheduled(startTime + delayInSeconds); // ���� ����
        startGame();
    }

    private void Update()
    {
        if(!audioSource.isPlaying) // ������ �÷��̵��� ���� �� ���� ����
            gameEnd();
    }

    // ���� ���� �Լ�
    void startGame()
    {
        gameClear.gameObject.SetActive(false); // ���� Ŭ���� ������Ʈ ��Ȱ��ȭ
        gameOver.gameObject.SetActive(false); // ���� ���� ������Ʈ ��Ȱ��ȭ
    }

    // ���� ���� �Լ�
    void gameEnd()
    {

        // ������ 25000 �� �̻��� ��� ���� Ŭ����
            if (scoreManager.score >= 25000)
            {
                gameClear.gameObject.SetActive(true);
            SceneManager.LoadScene("KJM_Map");

        }

        // ������ 25000 �̸��� ��� ���� ����
        else
            {
                gameOver.gameObject.SetActive(true);
            SceneManager.LoadScene("KJM_Map");
        }


    }
}
