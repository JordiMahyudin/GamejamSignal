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
    [SerializeField] private GameObject barcomplete;
    [SerializeField] private GameObject bar4;
    [SerializeField] private GameObject bar3;
    [SerializeField] private GameObject bar2;
    [SerializeField] private GameObject bar1;
    [SerializeField] private GameObject bar0;

    private void Awake()
    {
        flashLightSwitch = false;
        flashlight.SetActive(false);
        barImage = transform.Find("Bar").GetComponent<Image>();
        barcomplete.SetActive(false);
        bar4.SetActive(false);
        bar3.SetActive(false);
        bar2.SetActive(false);
        bar1.SetActive(false);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LowSignal"))
        {
            bar1.SetActive(true);
            bar0.SetActive(false);
        }
        else if (other.CompareTag("MidSignal"))
        {
            bar2.SetActive(true);
            bar0.SetActive(false);
        }
        else if (other.CompareTag("HighSignal"))
        {
            bar3.SetActive(true);
            bar0.SetActive(false);
        }
        else if (other.CompareTag("HigherSignal"))
        {
            bar4.SetActive(true);
            bar0.SetActive(false);
        }
        else if (other.CompareTag("MaxSignal"))
        {
            barcomplete.SetActive(true);
            bar0.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LowSignal") || other.CompareTag("MidSignal") || other.CompareTag("HighSignal") || other.CompareTag("HigherSignal") || other.CompareTag("MaxSignal"))
        {
            bar0.SetActive(true);
            barcomplete.SetActive(false);
            bar4.SetActive(false);
            bar3.SetActive(false);
            bar2.SetActive(false);
            bar1.SetActive(false);

        }
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
