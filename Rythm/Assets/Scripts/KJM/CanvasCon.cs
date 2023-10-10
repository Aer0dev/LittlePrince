using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasCon : SpriteFade
{
    public GameObject _FadeOut;
    public GameObject menuSet;
    public AudioSource audioSource;

    private void Update()
    {
        if (FadeOff)        //���� ���۵Ǹ� fadeout �˹����� false
        {
            Debug.Log("In");
            _FadeOut.SetActive(false);
            FadeOff = false;
        }


        //Sub Menu
        if (Input.GetButtonDown("Cancel"))      //cancel �Է½� �޴� on
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                menuSet.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }



    void Start()
    {
        Time.timeScale = 1f;
        Init();
        Faded();
 
    }


    //�޴� ����
    public void GameExit()
    {
        Application.Quit();
    }


    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoMap()
    {
        SceneManager.LoadScene("KJM_Map");

    }

}
