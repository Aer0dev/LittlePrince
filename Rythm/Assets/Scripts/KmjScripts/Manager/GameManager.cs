using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int hp;
    public int maxHealth = 3;
    public int count=0;

    public GameObject dieUI;

    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;
        hp = maxHealth;
    }

    private void Update()
    {
        if(hp>=maxHealth)
        {
            hp = maxHealth;
        }
        else if(hp <= 0)
        {
            hp = 0;
            dieUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void FixedUpdate()
    {
        count += 1;
    }
}
