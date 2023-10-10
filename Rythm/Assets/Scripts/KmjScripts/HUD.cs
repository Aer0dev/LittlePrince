using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image[] hpImage;
    public int playerHp;

    private void Awake()
    {
        
    }

    private void LateUpdate()
    {
        playerHp = GameManager.instance.hp;

        for (int i = 0; i < 3; i++)
        {
            hpImage[i].color = new Color(1, 1, 1, 0.3f);
        }

        for (int i=0;i<playerHp;i++)
        {
            hpImage[i].color = new Color(1, 1, 1, 1);
        }
    }
}
