using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFade : MonoBehaviour
{
    public AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }




    public IEnumerator SoundFadeOut()
    {

        while (audioSource.volume>=0f)
        {
            yield return new WaitForSeconds(0.05f);
            audioSource.volume -= 0.02f;
        }

    }
}
