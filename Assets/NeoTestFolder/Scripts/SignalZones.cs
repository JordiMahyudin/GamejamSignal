using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalZones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && this.CompareTag("Signal_1"))
        {
            Debug.Log("Signal reached");
        }
        if (other.CompareTag("Player") && this.CompareTag("Signal_2"))
        {
            Debug.Log("Signal reached");
        }
        if (other.CompareTag("Player") && this.CompareTag("Signal_3"))
        {
            Debug.Log("Signal reached");
        }
        if (other.CompareTag("Player") && this.CompareTag("Signal_4"))
        {
            Debug.Log("Signal reached");
        }
    }
}
