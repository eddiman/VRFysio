using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuBehavior : MonoBehaviour {

    private float timer;

    public float gazeTime = 1f;

    public bool gazedAt;
    private object Color;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (gazedAt)
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

        GetComponent<Renderer>().material.color = new Color(0, 0, 0);


        gazedAt = false;

    }

    public void PointerExit()
    {
        gazedAt = false;
        timer = 0;
    }
}
