using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_OnClick : SpriteFade
{
    static string sceneName = "KJM_Map";

    static private SoundFade soundFade;
    static bool BGMOn=false;
    static public bool PlanetFadeOut=false;

     void Start()
    {


        soundFade = FindObjectOfType<SoundFade>();
        if (soundFade != null&&BGMOn==false)        //audio play
        {
            BGMOn=true;
            AudioSource audioSource = soundFade.audioSource;
           audioSource.Play();
            Debug.Log("audio in");
        }
    }

    private void Update()
    {


        if (FadeOff)        //if fade out change scene
        {
            Debug.Log("out");
            SceneManager.LoadScene(sceneName);
            FadeOff = false;
        }
    }


    public void ClickStart()        //button click
    {

        if (SceneManager.GetSceneByName(sceneName) == null)
        {
            Debug.Log($"{sceneName}를(을) 찾을수 없습니다");
            return;
        }

        PlanetFadeOut = true;
         StartCoroutine(soundFade.SoundFadeOut());
        Init();
        Faded();
    }

    public void ClickLoad()     //로드 구현하지 않았음.
    {
        Debug.Log("로드");
    }

    public void ClickExit() //게임 종료
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }






}