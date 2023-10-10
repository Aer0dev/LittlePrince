using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerKMJ : MonoBehaviour
{
    public GameObject menuSet;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
          //  if (menuSet.activeSelf)
            {
                menuSet.SetActive(true);
                Time.timeScale = 0f;
            }
        }


    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoMap()
    {
        SceneManager.LoadScene("KJM_Map");
    }



}
