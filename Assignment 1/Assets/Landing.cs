using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var spaceShuttleTarget = transform.Find("SpaceShuttleTarget");
        var spaceShuttleMarking = spaceShuttleTarget.Find("Marking");
        var runwayTarget = transform.Find("RunwayTarget");

        var dotProductForward = Vector3.Dot(spaceShuttleTarget.forward, runwayTarget.forward);
        var dotProductRight = Vector3.Dot(spaceShuttleTarget.right, runwayTarget.right);

        Debug.LogError(nameof(dotProductForward) + dotProductForward);
        Debug.LogError(nameof(dotProductRight) + dotProductRight);

        var absDotProductForward = Math.Abs(dotProductForward);
        var absDotProductRight = Math.Abs(dotProductRight);

        const double margin = 0.92;
        const double highMargin = 0.50;

        if (absDotProductForward > margin && absDotProductRight > margin)
            spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.green;
        else if (absDotProductForward <= margin && absDotProductRight > highMargin || 
                 absDotProductForward > highMargin && absDotProductRight <= margin) 
            spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.yellow;
        else spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.red;
    }
}
