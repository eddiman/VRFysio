using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadTilt : MonoBehaviour
{
    private float timer;
    private float timeLeft;
    public float tiltTime;

    private bool left = false;
    private bool right = false;

    public Text text;

    // Use this for initialization
    void Start()
    {

        timeLeft = tiltTime;
        left = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (headTiltedLeft() && !Manager.leftTiltDone)
        {

            timer += Time.deltaTime;
            timeLeft -= Time.deltaTime;
            string timerString = timeLeft.ToString("0");

 
            text.text = "Hold for " + timerString + " seconds";

            Debug.Log(timer + " seconds has elapsed");


            if (timer >= tiltTime)
            {
                Manager.leftTiltDone = true;
                Debug.Log(Manager.leftTiltDone);
                text.text = "";
                timer = 0f;
                timeLeft = tiltTime;
                right = true;
                text.text = "";


            }

        }
     
         else if (headTiltedRight() && !Manager.rightTiltDone)
        {

            timer += Time.deltaTime;
            timeLeft -= Time.deltaTime;
            string timerString = timeLeft.ToString("0");


            text.text = "Hold for " + timerString + " seconds";

            if (timer >= tiltTime)
            {
                Manager.rightTiltDone = true;
                text.text = "";
                timer = 0f;
                timeLeft = tiltTime;
                text.text = "";




            }

        }
        else
        {
            timer = 0;
            timeLeft = tiltTime;
            text.text = "";

        }

    }



    bool headTiltedLeft() {
        if (Input.acceleration.x < -0.42)
        {

            return true;
        } else {
        return false;

        }
    }
    bool headTiltedRight() {
        if (Input.acceleration.x > 0.42)
        {
            return true;
        } else {
        return false;

        }
    }



}
