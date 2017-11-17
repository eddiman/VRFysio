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

                default:
                    timerText.text = "Starting in " + timerString;
                    break;

            }

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;
                Debug.Log("TextTimer is 0");
                




            }
            
        }
    }

    public void PointerEnter()
    {
        Debug.Log("Enter");
        gazedAt = true;
        GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);


    }

    public void PointerClick()
    {

        txt.color = new Color(1f, 1f, 1f);

        switch (GetComponent<Text>().name)
        {
            case "ResetButton":
                timerText.text = "Resetting...";
                Application.LoadLevel(Application.loadedLevel);

                Manager.resetAll();

                break;

            case "StartButton":
                timerText.text = "Loading...";
                SceneManager.LoadScene("test_scene");
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                Manager.resetAll();
                break;
            case "StartMenuButton":

                timerText.text = "Loading...";
                SceneManager.LoadScene("menu_scene");
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                Manager.resetAll();
            
                break;

            case "NextSceneButton":

                timerText.text = "Loading...";
                SceneManager.LoadScene("test_scene_2");
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                break;
        }




        gazedAt = false;

    }

    public void PointerExit()
    {
                GetComponent<Text>().color = new Color(1f, 1f, 1f);
                timerText.text = "";
             
        //Resets variables
        gazedAt = false;
        timer = 0;
        timeLeft = gazeTime;
    }
}
