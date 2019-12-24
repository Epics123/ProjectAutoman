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

    bool grounded = false;

    public float xsp, ysp;

    RaycastHit2D aSensor;
    RaycastHit2D bSensor;
    RaycastHit2D cSensor;
    RaycastHit2D dSensor;
    RaycastHit2D eSensor;
    RaycastHit2D fSensor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grounded);
    }

    void FixedUpdate()
    {
        CheckCollisions();
    }

    void CheckCollisions()
    {
        aSensor = Physics2D.Raycast(leftSensorStart.position, Vector2.down, vertSensorLength);
        bSensor = Physics2D.Raycast(rightSensorStart.position, Vector2.down, vertSensorLength);
        cSensor = Physics2D.Raycast(leftSensorStart.position, Vector2.up, vertSensorLength);
        dSensor = Physics2D.Raycast(rightSensorStart.position, Vector2.up, vertSensorLength);
        eSensor = Physics2D.Raycast(midSensorStart.position, Vector2.left, horizSensorLength);
        fSensor = Physics2D.Raycast(midSensorStart.position, Vector2.right, horizSensorLength);

        CheckGround(aSensor, bSensor);

        DrawSensors();
    }

    bool CheckGround(RaycastHit2D sensorA, RaycastHit2D sensorB)
    {
        if ((sensorA.collider != null) || (sensorB.collider != null))
            grounded = true;
        else
            grounded = false;

        return grounded;
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
