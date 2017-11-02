using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBox : MonoBehaviour {

    public Text midStarterText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Manager.leftDone && Manager.rightDone && Manager.topDone)
        {
            midStarterText.text = "All of them are now done!";
        }

        if (Manager.leftDone && Manager.rightDone && !Manager.topDone)
        {
            midStarterText.text = "Move your head along the elements on the top.";
        }

        if (Manager.leftDone && !Manager.rightDone && !Manager.topDone)
        {
            midStarterText.text = "Move your head along the elements to the right.";
        }

        if (Manager.leftDone && Manager.rightDone && !Manager.topDone)
        {
            midStarterText.text = "Move your head along the elements on the top.";
        }


    }
}
