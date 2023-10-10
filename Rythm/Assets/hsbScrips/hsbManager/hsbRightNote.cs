using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// 오른쪽 노트 컨트롤 스크립트
public class hsbRightNote : MonoBehaviour
{
    Stopwatch stopwatch;
    public GameObject Right; // 오른쪽 노트
    public float noteSpeed = 1f; // 노트 스피드
    private bool check; // 맞는지 아닌지 체크하는 변수

    public GameObject Effect; // 효과
    private hsbScoreManager scoreM;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        scoreM = FindObjectOfType<hsbScoreManager>();
    }


    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();

    }

    void Update()
    {
        transform.Translate(Vector3.down * noteSpeed * Time.smoothDeltaTime); // 노트 스피드만큼 밑으로 이동

        // D키를 누르면
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (check) // 체크 변수가 true일 때만
            {
                stopwatch.Stop();
                scoreM.score += 100; // 점수 100점씩 추가
                GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity); // 효과 발생
                Destroy(effect, 0.2f); // 삭제
                Destroy(Right); // 오른쪽 노트 삭제

                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
            }

        }


    }

    // 충돌 감지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit")) // 특정 히트박스 충돌 시
            check = true; // 체크  = 참

        if (collision.CompareTag("Right")) // 히트박스 벗어날 시
        {
            check = false; // 실패

            Destroy(Right); // 노트 사라짐
            UnityEngine.Debug.Log("실패");
        }

    }

}


