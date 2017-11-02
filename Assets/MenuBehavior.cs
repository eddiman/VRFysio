using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuBehavior : MonoBehaviour {

    private float timer;
    float timeLeft;
    public Text timerText;
    public float gazeTime = 1f;
    Text txt;

    public bool gazedAt;
    private object Color;

   

    // Use this for initialization
    void Start () {
        timer = 0;
        txt = GetComponentInChildren<Text>();
        timeLeft = gazeTime;

    }

    // Update is called once per frame
    void Update() {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);


            timeLeft -= Time.deltaTime;
            string timerString = timeLeft.ToString("0");


            switch (GetComponent<Text>().name)
            {
                case "ResetButton":
                    timerText.text = "Reset in " + timerString;
                    break;

                case "StartButton":
                    timerText.text = "Starting in " + timerString;
                    break;
            }

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;
                Debug.Log("Timer is 0");
                




            }
            
        }
    }

    public void PointerEnter()
    {
        Debug.Log("Enter");
        gazedAt = true;
        switch (GetComponent<Text>().name)
        {
            case "ResetButton":
                GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
                break;

            case "StartButton":
                GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
                break;
        }

    }

    public void PointerClick()
    {
        switch (GetComponent<Text>().name)
        {
            case "ResetButton":
                txt.color = new Color(1f, 1f, 1f);
                timerText.text = "Resetting...";
                Application.LoadLevel(Application.loadedLevel);

                Manager.leftDone = false;
                Manager.rightDone = false;
                Manager.topDone = false;

                break;

            case "StartButton":
                txt.color = new Color(1f, 1f, 1f);
                timerText.text = "Starting...";
                SceneManager.LoadScene("test_scene");
                SceneManager.UnloadScene("menu_scene");
                break;
        }




        gazedAt = false;

    }

    public void PointerExit()
    {
        switch (GetComponent<Text>().name)
        {
            case "ResetButton":
                GetComponent<Text>().color = new Color(1f, 1f, 1f);
                timerText.text = "";
                break;

            case "StartButton":
                GetComponent<Text>().color = new Color(1f, 1f, 1f);
                timerText.text = "";
                break;
        }
        //Resets variables
        gazedAt = false;
        timer = 0;
        timeLeft = gazeTime;
    }
}
