using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenterFlame : SpriteFade
{
    AudioSource myAudio;

    public bool isStart;
    bool musicStart = false;
    int count = 0;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (FadeOff)
        {
            Debug.Log("out");
            SceneManager.LoadScene("KJM_Map");
            FadeOff = false;
        }





        if (GameManager.instance.hp <= 0)
        {
            myAudio.Stop();
        }

       if (!myAudio.isPlaying&&isStart&&GameManager.instance.hp>0)
        {
            if(count==1)
            {
            Debug.Log("Å¬¸®¾î!");
            Init();
            Faded();
            }
            count++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                myAudio.Play();
                musicStart = true;
                isStart = true;
            }
        }
    }
}
