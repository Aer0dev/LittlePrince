using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

// 좌측 노트 컨트롤 스크립트
public class hsbLeftNote : MonoBehaviour
{
    public AudioSource hit;
    Stopwatch stopwatch; 
    public GameObject Left;
    public GameObject Effect;
    public float noteSpeed = 4f;
    private bool check = false;

    private hsbScoreManager scoreManager;


    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        scoreManager = FindObjectOfType<hsbScoreManager>();

    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();

    }

    void Update()
    {

        transform.Translate(Vector3.up * noteSpeed * Time.deltaTime); // 노트 스피드만큼 위쪽으로 이동

        //  A 키를 누르면 없어짐
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(check) // check 가 true일 때
            {

                stopwatch.Stop();
                scoreManager.score += 100; // 점수 100점씩 추가
                GameObject effect = Instantiate(Effect, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.4f, transform.position.z), Quaternion.identity); // 효과 작동
                Destroy(effect, 0.2f); // 효과 0.1초 뒤에 삭제
                Destroy(Left); // 노트 삭제
                
                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
            }

        }
    }

    // 충돌 감지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit")) // 적정 히트 박스에 맞으면 true
            check = true;

        if (collision.CompareTag("Left")) // 넘어가면 false 후 노트 삭제
        {
            check = false;

            Destroy(Left);
            UnityEngine.Debug.Log("실패");
        }

    }

}
