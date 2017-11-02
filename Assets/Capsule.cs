using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Capsule : MonoBehaviour {

    private float timer;

    public float gazeTime = 1f;

    public bool gazedAt;

    public GameObject textgameobject;



    Text TextRemainingLeft;

    Capsule LeftComp;


	// Use this for initialization
	void Start () {
        

        TextRemainingLeft = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
		if(gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;


            }

            if (Manager.leftFinished) {
                setComponentToFinished(GetComponent<Capsule>());
                Debug.Log("Left is finished");

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

                break;

            case "RightComp":
                setComponentToFinished(GetComponent<Capsule>());

                break;

            case "TopComp":
                setComponentToFinished(GetComponent<Capsule>());

                break;
            default:

                
                setComponentToFinished(GetComponent<Capsule>());

                    break;


        }




        //Sets the comp to be false, cannot interact ith it anymore
        
        gazedAt = false;

    }

    public void setComponentToFinished(Component component)
    {
        
        component.GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

        component.GetComponent<Collider>().enabled = false;
    }

    public void PointerExit() { 
        gazedAt = false;
        timer = 0;
    }
      


}


