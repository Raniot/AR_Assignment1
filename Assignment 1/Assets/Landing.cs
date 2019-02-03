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
        var spaceShuttle = spaceShuttleTarget.Find("SpaceShuttle");
        var spaceShuttleMarking = spaceShuttleTarget.Find("Marking");
        var runwayTarget = transform.Find("RunwayTarget");
        var runway = runwayTarget.Find("Runway");

        var spaceShuttlePosition = spaceShuttle.position;
        spaceShuttlePosition.z += 1;


        //var crossProduct = Vector3.Cross(runway.position, spaceShuttle.position);
        var test = new Vector2 {x = spaceShuttle.position.x, y = spaceShuttle.position.z};
        var test2 = new Vector2 {x = runway.position.x, y = runway.position.z};
        //var dotProduct = Vector3.Dot(spaceShuttle.position, runwayTarget.position);
        var angle = Vector3.Angle(spaceShuttle.up, runway.up);
        //var dotProduct = Vector3.Dot(spaceShuttle.position * spaceShuttle.lossyScale, runway.position.normalized);
        var dotProduct = Vector2.Dot(spaceShuttle.position, runway.position);

        Debug.Log(nameof(dotProduct) + dotProduct);
        Debug.Log(nameof(angle) + angle);

        var AbsDotProduct = Math.Abs(dotProduct);

        if (AbsDotProduct <= 0) spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.green;
        else if (AbsDotProduct <= 50) spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.blue;
        else if (AbsDotProduct <= 100) spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.cyan;
        else if (AbsDotProduct <= 200) spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.magenta;
        else spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.red;


        //if (dotProduct <= 0)
        //{

        //}
        //else
        //{
        //    spaceShuttleMarking.GetComponent<Renderer>().material.color = Color.red;
        //}
        //runwayTarget
        //transform.


        //quad.
        //var earth = sun.Find("Earth");
    }
}
