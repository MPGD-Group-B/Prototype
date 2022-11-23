using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int points = 0;

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,300,20), "Waste Collected: " + points);
    }
}
