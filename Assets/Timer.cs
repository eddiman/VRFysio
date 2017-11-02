using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text text;

    float originalTimeLeft;
    float timeLeft;
    float timer;

    bool isOnPoint = false;
    bool finished;

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isOnPoint)
        {
            finished = false;
            timeLeft -= Time.deltaTime;
            string timerString = timeLeft.ToString("0");
           
            text.text = "Hold for " + timerString + " seconds";

            if(timeLeft <= 0)
            {

                isOnPoint = false;
                finished = true;
                
            }
        } 

    }

    public void startTimer()
    {
        if (!isOnPoint)
        {
            isOnPoint = true;

        }
    }

    public void setTimer(float timer)
    {
        if (!isOnPoint)
        {

            originalTimeLeft = timer;
            timeLeft = timer;
        }
    }



    public void stopTimer()
    {
        isOnPoint = false;
        this.timeLeft = originalTimeLeft;

        text.text = "Hold for " + originalTimeLeft.ToString() + " seconds";
        if (finished)
        {
                text.text = "You did it!";

        }

    }



}
