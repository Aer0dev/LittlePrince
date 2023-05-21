using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Slider mySlider;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        mySlider.value = GameManager.instance.hp / GameManager.instance.maxHealth;
    }
}
