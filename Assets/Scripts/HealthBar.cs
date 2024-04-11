using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setHealth(float health)
    {
        slider.value = health;
    }

    public void setMaxHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health; // ensure slider starts at max health
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
