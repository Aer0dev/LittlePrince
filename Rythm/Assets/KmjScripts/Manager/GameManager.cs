using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float hp;
    public float maxHealth = 100;

    private void Awake()
    {
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
        }
    }
}
