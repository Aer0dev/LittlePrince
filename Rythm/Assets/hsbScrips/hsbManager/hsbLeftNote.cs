using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

// ���� ��Ʈ ��Ʈ�� ��ũ��Ʈ
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

        transform.Translate(Vector3.up * noteSpeed * Time.deltaTime); // ��Ʈ ���ǵ常ŭ �������� �̵�

        //  A Ű�� ������ ������
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(check) // check �� true�� ��
            {

                stopwatch.Stop();
                scoreManager.score += 100; // ���� 100���� �߰�
                GameObject effect = Instantiate(Effect, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.4f, transform.position.z), Quaternion.identity); // ȿ�� �۵�
                Destroy(effect, 0.2f); // ȿ�� 0.1�� �ڿ� ����
                Destroy(Left); // ��Ʈ ����
                
                UnityEngine.Debug.Log(stopwatch.ElapsedMilliseconds + " ms");
            }

        }
    }

    // �浹 ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hit")) // ���� ��Ʈ �ڽ��� ������ true
            check = true;

        if (collision.CompareTag("Left")) // �Ѿ�� false �� ��Ʈ ����
        {
            check = false;

            Destroy(Left);
            UnityEngine.Debug.Log("����");
        }

    }

}
