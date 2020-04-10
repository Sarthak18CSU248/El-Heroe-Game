using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SphericalVector // value type
{
    public float Length;
    public float Zenith;
    public float Azimuth;

    public SphericalVector(float azimuth,float zenith,float length)
    {
        Length = length;
        Zenith = zenith;
        Azimuth = azimuth;
    }
    public Vector3 Direction
    {
        get

        {
            Vector3 dir;
            float vertical_angle = Zenith * Mathf.PI / 2f; // Verticla Angle
            dir.y = Mathf.Sin(vertical_angle);
            float h = Mathf.Cos(vertical_angle);

            float horizontal_angle = Azimuth * Mathf.PI;
            dir.x = h * Mathf.Sin(horizontal_angle);
            dir.z = h * Mathf.Cos(horizontal_angle);

            return dir;
        }
    }

    public Vector3 Position
    {
        get

        {
            return Length * Direction;
        }
    }
} //struct
