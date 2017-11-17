using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackBox : MonoBehaviour {

    public Text midStarterText;

	// Use this for initialization
	void Start () {
	    midStarterText.text = "To perform excercise, move your head over all of the capsules. Start with the elements on the left.";

    }

    // Update is called once per frame
    void Update () {



        if (!Manager.leftTiltDone && !Manager.rightTiltDone && SceneManager.GetActiveScene().name == "test_scene_2")
	    {
	        midStarterText.text = "Tilt your head to either side, as in the picture";
	    }



        /*TILT*/
        if (Manager.leftTiltDone && Manager.rightTiltDone)
	    {
	        midStarterText.text = "All of them are now done! Press the button under you to go back to main menu!";
	    }

	    if (!Manager.leftTiltDone && Manager.rightTiltDone)
	    {
	        midStarterText.text = "Tilt your head to left, as in the picture";
	    }

        if (Manager.leftTiltDone && !Manager.rightTiltDone)
	    {
	        midStarterText.text = "Tilt your head to right, as in the picture";
	    }
	    /*^TILT^*/


        if (Manager.leftDone && Manager.rightDone && Manager.topDone && SceneManager.GetActiveScene().name == "test_scene")
        {
            midStarterText.text = "All of them are now done! \n Select 'Next Scene' under you for the next exercise.";
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
