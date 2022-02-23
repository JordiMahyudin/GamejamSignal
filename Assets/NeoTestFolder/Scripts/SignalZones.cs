using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalZones : MonoBehaviour
{
    [SerializeField] private Transform Signal_1;
    [SerializeField] private Transform Signal_2;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Signal reached");
        //Do something

        if(other.CompareTag("Player"))
        {
            Debug.Log("Signal reached");
        }
    }
}
