using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarController : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private Text healthText;

    private int health=100;

    void Start()
    {
        slider = GetComponent<Slider>();
        
    }

    public void UpdateSliderValue(int hp)
    {
        health += hp;
        healthText.text = health.ToString();
        slider.value = (float)health / 100;
    }

    public void increaseHealth(int hp)
    {
        health -= hp;
        healthText.text = health.ToString();
        slider.value = (float)health / 100;
    }
}
