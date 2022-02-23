using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryDepletion : MonoBehaviour
{

    private Battery battery;
    private Image barImage;
    [SerializeField] private bool flashLightSwitch;
    [SerializeField] private GameObject flashlight;

    private void Awake()
    {
        flashLightSwitch = false;
        flashlight.SetActive(false);
        barImage = transform.Find("Bar").GetComponent<Image>();

        battery = new Battery();
    }

    private void Update()
    {
        battery.Update();

        if (flashLightSwitch == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                flashlight.SetActive(true);
                flashLightSwitch = true;
            }
        }
        else if (flashLightSwitch == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                flashlight.SetActive(false);
                flashLightSwitch = false;
            }
        }
        barImage.fillAmount = battery.GetNormalized();
    }
}

public class Battery
{
    public const int ENERGY_MAX = 100;

    private float energyAmount = 100;
    private float EnergyDepletion = 0.1f;

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
