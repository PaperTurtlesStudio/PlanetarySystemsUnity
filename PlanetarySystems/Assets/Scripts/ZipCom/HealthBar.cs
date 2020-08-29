using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public void SetMaxHealth(float Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;
    }

    public void SetHealth(float Health)
    {
        Slider.value = Health;
    }
}
