using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryDepletion : MonoBehaviour
{

    private Battery battery;
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        battery = new Battery();
    }

    private void Update()
    {
        battery.Update();

        barImage.fillAmount = battery.GetNormalized();
    }
}

public class Battery
{
    public const int ENERGY_MAX = 100;

    private float energyAmount = 100;
    private float EnergyDepletion = 1f;

    public void Update()
    {
        energyAmount -= EnergyDepletion * Time.deltaTime;
    }
    
    public void Flashlight (int amount)
    {
        if (energyAmount >= amount)
        {
            energyAmount -= amount;
        }
    }

    public float GetNormalized()
    {
        return energyAmount / ENERGY_MAX;
    }
}
