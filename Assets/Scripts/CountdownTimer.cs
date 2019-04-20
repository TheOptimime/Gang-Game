using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 600f;

    [SerializeField] Text countdownTimer;
    void Start()
    {
        currentTime = startingTime;
        string.Format("{0:00}", currentTime);
    }

   
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
    }

}
