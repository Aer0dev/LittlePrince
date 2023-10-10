using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// ������ ��Ʈ ��Ʈ�� ��ũ��Ʈ
public class hsbRightNote : MonoBehaviour
{
    Stopwatch stopwatch;
    public GameObject Right; // ������ ��Ʈ
    public float noteSpeed = 1f; // ��Ʈ ���ǵ�
    private bool check; // �´��� �ƴ��� üũ�ϴ� ����

    public GameObject Effect; // ȿ��
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
        transform.Translate(Vector3.down * noteSpeed * Time.smoothDeltaTime); // ��Ʈ ���ǵ常ŭ ������ �̵�

        // DŰ�� ������
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (check) // üũ ������ true�� ����
            {
                stopwatch.Stop();
                scoreM.score += 100; // ���� 100���� �߰�
                GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity); // ȿ�� �߻�
                Destroy(effect, 0.2f); // ����
                Destroy(Right); // ������ ��Ʈ ����

                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
            }

        }


    }

    // �浹 ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit")) // Ư�� ��Ʈ�ڽ� �浹 ��
            check = true; // üũ  = ��

        if (collision.CompareTag("Right")) // ��Ʈ�ڽ� ��� ��
        {
            check = false; // ����

            Destroy(Right); // ��Ʈ �����
            UnityEngine.Debug.Log("����");
        }

    }

}


