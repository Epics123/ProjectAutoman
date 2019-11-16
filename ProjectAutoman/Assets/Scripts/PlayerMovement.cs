using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform xyPos, rightSensorStart, leftSensorStart, midSensorStart;
    public float vertSensorLength, horizSensorLength;

    float acc = 0.046875f;
    float dec = 0.5f;
    float frc = 0.046875f;
    float topSpeed = 6.0f;
    float jumpHeight = 6.5f;
    float slope = 0.125f;
    float slpRollUp = 0.078125f;
    float slpRollDown = 0.3125f;
    float fall = 2.5f;
    float gsp = 0.0f;

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

    void MoveHorizontal()
    {

    }
}
