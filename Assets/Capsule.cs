using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Capsule : MonoBehaviour {

    private float timer;

    public float gazeTime = 1f;

    public bool gazedAt;







	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		if(gazedAt)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= gazeTime)
            {
                Debug.Log("timer " + timer + " is greaater than gazeTime" + gazeTime);

                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;


            }

            /*TODO: Find a cleaner solution */

            if (Manager.leftFinished) {
                setComponentToFinished(GetComponent<Capsule>());
                Debug.Log("Left is finished");
                Manager.leftDone = true;
                Manager.leftFinished = false;

            }

            if (Manager.rightFinished)
            {
                setComponentToFinished(GetComponent<Capsule>());
                Debug.Log("Right is finished");
                Manager.rightDone = true;
                Manager.rightFinished = false;

            }

            if (Manager.topFinished)
            {
                setComponentToFinished(GetComponent<Capsule>());
                Debug.Log("Top is finished");
                Manager.topDone = true;
                Manager.topFinished = false;

            }


        }
    }

    public void PointerEnter()
    {

        gazedAt = true;

    }
    public void PointerClick()
    {

        switch (GetComponent<Capsule>().name)
        {
            case "LeftComp":
                Manager.leftFinished = true;
                Debug.Log("leftFinished" +  Manager.leftFinished);
                break;

            case "RightComp":
                Manager.rightFinished = true;
                Debug.Log("rightFinished" + Manager.rightFinished);
                break;

            case "TopComp":
                Manager.topFinished = true;
                Debug.Log("topFinished" + Manager.topFinished);
                break;

            default:
                Debug.Log("default");
                setComponentToFinished(GetComponent<Capsule>());
                break;


        }




        //Sets the comp to be false, cannot interact ith it anymore
        
        gazedAt = false;

    }

    public void setComponentToFinished(Component component)
    {
                Debug.Log(component.name + " finished");

        component.GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

        component.GetComponent<Collider>().enabled = false;
        timer = 0;
    }

    public void setComponentToUnfinished(Component component)
    {
        Debug.Log(component.name + " unfinished");
        component.GetComponent<Renderer>().material.color = Color.white;
    
        component.GetComponent<Collider>().enabled = true;

    }


    public void PointerExit() { 
        gazedAt = false;
        timer = 0;
    }
      


}


