using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// ���� �� UI ��Ʈ�� ��ũ��Ʈ
public class hsbScoreManager : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText; // ���ھ� UI
    
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
