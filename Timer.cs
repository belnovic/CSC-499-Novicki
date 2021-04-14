using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 10.0f;
    public bool isRunning = false;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //starts the timer upon first click
        if (Input.GetMouseButtonDown(0))
        {
            isRunning = true;
        }

        //count down the timer
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
            }
        }


    }

    void DisplayTime(float timeDisplayed)
    {
        //displays the time remaining on a text object
        timeDisplayed += 1;

        float seconds = Mathf.FloorToInt(timeDisplayed % 60);

        timeText.text = seconds.ToString();

    }
}
