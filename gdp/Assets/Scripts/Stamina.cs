using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{

    public float AmountOfStamina;
    public Slider slider;
    public float RateOfDrain;

    void Start()
    {
        AmountOfStamina = 100f;
        RateOfDrain = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (AmountOfStamina > 100)
        {
            AmountOfStamina = 100;
        }
        else if (AmountOfStamina < 0)
        {
            AmountOfStamina = 0;
        }

        slider.value = AmountOfStamina;
        RefillStamina();
        AmountOfStamina -= RateOfDrain * Time.deltaTime;
    }

    public void RefillStamina()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            AmountOfStamina += 50f;
        }
    }

    public void IncreasedStaminaDrain() //function to be used in the future
    {
        RateOfDrain = 2;
    }

}