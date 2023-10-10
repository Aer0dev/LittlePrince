using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 오른쪽 충돌 체크-> 효과음
public class hsbHitSoundRight : MonoBehaviour
{
    private bool check;
    // Start is called before the first frame update

    public AudioSource hit;
    void Start()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (check)
            {
                hit.Play();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            check = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            check = false;
        }
    }
}
