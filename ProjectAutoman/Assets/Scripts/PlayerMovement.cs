using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform xyPos, rightSensorStart, leftSensorStart, midSensorStart;
    public float vertSensorLength, horizSensorLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        CheckCollisions();
    }

    void CheckCollisions()
    {
        RaycastHit2D aSensor = Physics2D.Raycast(leftSensorStart.position, Vector2.down, vertSensorLength);
        RaycastHit2D bSensor = Physics2D.Raycast(rightSensorStart.position, Vector2.down, vertSensorLength);
        RaycastHit2D cSensor = Physics2D.Raycast(leftSensorStart.position, Vector2.up, vertSensorLength);
        RaycastHit2D dSensor = Physics2D.Raycast(rightSensorStart.position, Vector2.up, vertSensorLength);
        RaycastHit2D eSensor = Physics2D.Raycast(midSensorStart.position, Vector2.left, horizSensorLength);
        RaycastHit2D fSensor = Physics2D.Raycast(midSensorStart.position, Vector2.right, horizSensorLength);

        DrawSensors();
    }

    void DrawSensors()
    {
        //Draw floor sensors
        Debug.DrawRay(leftSensorStart.position, Vector2.down * vertSensorLength, Color.green);
        Debug.DrawRay(rightSensorStart.position, Vector2.down * vertSensorLength, Color.cyan);
        //Draw ceiling sensors
        Debug.DrawRay(leftSensorStart.position, Vector2.up * vertSensorLength, Color.blue);
        Debug.DrawRay(rightSensorStart.position, Vector2.up * vertSensorLength, Color.yellow);
        //Draw wall collision sensors
        Debug.DrawRay(midSensorStart.position, Vector2.left * horizSensorLength, Color.magenta);
        Debug.DrawRay(midSensorStart.position, Vector2.right * horizSensorLength, Color.red);
    }
}
