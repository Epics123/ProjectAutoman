using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform rightSensorStart, leftSensorStart, midSensorStart;
    public float vertSensorLength, horizSensorLength;

    public bool grounded = false;

    public float xsp, ysp, gsp;

    RaycastHit2D aSensor;
    RaycastHit2D bSensor;
    RaycastHit2D cSensor;
    RaycastHit2D dSensor;
    RaycastHit2D eSensor;
    RaycastHit2D fSensor;

    public Transform tmp;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(grounded);
    }

    void FixedUpdate()
    {
        CheckCollisions();
        CheckMovement();
        UpdatePosition();
        Debug.Log(gsp);
    }

    void CheckCollisions()
    {
        //Update sensors
        aSensor = Physics2D.Raycast(leftSensorStart.position, Vector2.down, vertSensorLength);
        bSensor = Physics2D.Raycast(rightSensorStart.position, Vector2.down, vertSensorLength);
        cSensor = Physics2D.Raycast(leftSensorStart.position, Vector2.up, vertSensorLength);
        dSensor = Physics2D.Raycast(rightSensorStart.position, Vector2.up, vertSensorLength);
        eSensor = Physics2D.Raycast(midSensorStart.position, Vector2.left, horizSensorLength);
        fSensor = Physics2D.Raycast(midSensorStart.position, Vector2.right, horizSensorLength);

        //Check for ground collision
        CheckGround(aSensor, bSensor);

        //Draw sensors in editor
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

    void CheckFall()
    {
        if (!grounded)
        {
            ysp -= Movement.GRV;
            if (ysp < -Movement.MAX_FALL_SPEED)
                ysp = -Movement.MAX_FALL_SPEED;
        }
        else
            ysp = 0f;
    }

    void CheckMovement()
    {
        CheckFall();
        MoveHorizontal();
        MoveVertical();
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
        //Moving Left
        if(Input.GetAxis("Horizontal") < 0)
        {
            if(gsp > 0)
            {
                gsp -= Movement.DECEL;
                if (gsp <= 0)
                    gsp = -0.5f;
            }
            else if(gsp > -Movement.TOP_SPEED)
            {
                gsp -= Movement.ACCEL;
                if (gsp <= -Movement.TOP_SPEED)
                    gsp = -Movement.TOP_SPEED;
            }
        }

        //Moving Right
        if(Input.GetAxis("Horizontal") > 0)
        {
            if(gsp < 0)
            {
                gsp += Movement.DECEL;
                if (gsp >= 0)
                    gsp = 0.5f;
            }
            else if(gsp < Movement.TOP_SPEED)
            {
                gsp += Movement.ACCEL;
                if (gsp >= Movement.TOP_SPEED)
                    gsp = Movement.TOP_SPEED;
            }
        }

        //No Horizontal Input
        if(Input.GetAxis("Horizontal") == 0)
        {
            gsp -= Mathf.Min(Mathf.Abs(gsp), Movement.FRC) * Mathf.Sign(gsp);
        }
    }

    void MoveVertical()
    {
        
    }

    void UpdatePosition() 
    {
        xsp = Movement.UpdateHorizontalSpeed(gsp, transform.rotation.z);
        ysp = Movement.UpdateVerticalSpeed(gsp, transform.rotation.z);

        transform.Translate(new Vector3(xsp * Time.deltaTime, ysp * Time.deltaTime));
    }

}
