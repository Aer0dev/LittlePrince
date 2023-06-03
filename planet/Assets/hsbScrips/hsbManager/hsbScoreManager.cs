using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hsbScoreManager : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameClear;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameClear.gameObject.SetActive(false);
    }

    void startGame()
    {
        gameClear.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Mathf.FloorToInt(score).ToString();

    }
}
