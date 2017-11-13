using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    protected Manager() { } // guarantee this will be always a singleton only - can't use the constructor!

    public static bool leftFinished = false;
    public static bool rightFinished = false;
    public static bool topFinished = false;

    public static bool leftTiltFinished = false;
    public static bool rightTiltFinished = false;

    public static bool leftDone = false;
    public static bool rightDone= false;
    public static bool topDone= false;

    public static bool leftTiltDone= false;
    public static bool rightTiltDone= false;


    public static void resetAll()
    {
    leftFinished = false;
    rightFinished = false;
    topFinished = false;

    leftTiltFinished = false;
    rightTiltFinished = false;

    leftDone = false;
    rightDone = false;
    topDone = false;

    leftTiltDone = false;
    rightTiltDone = false;
}
}
