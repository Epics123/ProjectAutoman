using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Movement
{
    public const float ACCEL = 0.046875f;
    public const float DECEL = 0.5f;
    public const float FRC = 0.046875f;
    public const float TOP_SPEED = 6.0f;
    public const float MAX_FALL_SPEED = 16f;

    public static float jumpHeight = 6.5f;
    public static float slope = 0.125f;
    public static float slpRollUp = 0.078125f;
    public static float slpRollDown = 0.3125f;
    public static float fall = 2.5f;
    public static float gsp = 0.0f;
    public static float grv = 0.21875f;


    public static float UpdateHorizontalSpeed(float gsp, float angle)
    {
        float xsp = gsp * Mathf.Cos(angle);
        return xsp;
    }

    public static float UpdateVerticalSpeed(float gsp, float angle)
    {
        float ysp = gsp * -Mathf.Sin(angle);
        return ysp;
    }
}
