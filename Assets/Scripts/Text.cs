using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI Text_1;
    public TextMeshProUGUI Text_2;
    private float timeToAppear = 5f;
    private float timeWhenDisappear;

    public void Start()
    {
        Text_1.gameObject.SetActive(true);
        timeWhenDisappear = Time.time + timeToAppear;
    }
    //Call to enable the text, which also sets the timer
    
    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        if (Text_1.enabled && (Time.time >= timeWhenDisappear))
        {
            Text_1.gameObject.SetActive(false);
            EnableText();
        }
        if (Text_2.enabled && (Time.time >= timeWhenDisappear))
        {
            Text_2.gameObject.SetActive(false);
        }
    }
    public void EnableText()
    {
        Debug.Log("Fuck");
        Text_2.gameObject.SetActive(true);
        Debug.Log("Fuck");
        timeWhenDisappear = Time.time + timeToAppear;
    }

}
