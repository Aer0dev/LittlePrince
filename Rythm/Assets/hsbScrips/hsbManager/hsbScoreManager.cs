using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 점수 및 UI 컨트롤 스크립트
public class hsbScoreManager : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText; // 스코어 UI
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = Mathf.FloorToInt(score).ToString();

    }
}
