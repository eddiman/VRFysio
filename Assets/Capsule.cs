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
                Debug.Log("Timer is 0");

            }
        }
    }

    public void PointerEnter()
    {
        Debug.Log("Enter");
        gazedAt = true;

    }
    public void PointerClick()
    {

        switch (GetComponent<Capsule>().name)
        {
            case "LeftComp":
                GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

                GetComponent<Collider>().enabled = false;
                gazedAt = false;

                break;

            case "RightComp":
                GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

                GetComponent<Collider>().enabled = false;
                gazedAt = false;

                break;

            case "TopComp":
                GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

                GetComponent<Collider>().enabled = false;
                gazedAt = false;

                break;
            default:
                    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

                    GetComponent<Collider>().enabled = false;
                    gazedAt = false;
                    break;


        }


        //Sets the comp to be false, cannot interact ith it anymore
        
        gazedAt = false;

    }

    public void PointerExit() { 
        gazedAt = false;
        timer = 0;
    }
      


}
