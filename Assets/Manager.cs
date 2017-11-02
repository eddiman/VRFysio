using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Manager : MonoBehaviour
{
    protected Manager() { } // guarantee this will be always a singleton only - can't use the constructor!

    public static bool leftFinished = false;
}
