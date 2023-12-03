using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject border, fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void Update()
    {
        if(slider.value == slider.maxValue)
        {
            border.GetComponent<Image>().enabled = false;
            fill.GetComponent<Image>().enabled = false;
        }
        else
        {
            border.GetComponent<Image>().enabled = true;
            fill.GetComponent<Image>().enabled = true;
        }
    }
}
