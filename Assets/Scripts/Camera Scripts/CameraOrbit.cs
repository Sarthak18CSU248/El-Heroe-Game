﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : Orbit
{
    public Vector3 target_Offset = new Vector3(0, 2, 0);
    public Vector3 camera_Position_Zoom = new Vector3(-0.5f, 0, 0);
    public float camera_Length = -10f;
    public float camera_Length_Zoom = -5f;
    public Vector2 orbit_Speed = new Vector2(0.01f, 0.01f);
    public Vector2 orbit_Offset = new Vector2(0, -0.8f);
    public Vector2 angle_Offset = new Vector2(0, -0.25f);

    private float zoomValue;
    private Vector3 camera_Position_Temp;
    private Vector3 camera_Position;

    private Transform playerTarget;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        spherical_Vector_Data.Length = camera_Length;
        spherical_Vector_Data.Azimuth = angle_Offset.x;
        spherical_Vector_Data.Zenith = angle_Offset.y;

        mainCamera = Camera.main;
        camera_Position_Temp = mainCamera.transform.localPosition;
        camera_Position = camera_Position_Temp;

        MouseLock.MouseLocked = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTarget)
        {
            HandleCamera();
            handleMouseLocking();
        }
    }
    void HandleCamera()
    {
        if (MouseLock.MouseLocked)
        {
            spherical_Vector_Data.Azimuth += Input.GetAxis("Mouse X") * orbit_Speed.x;
            spherical_Vector_Data.Zenith += Input.GetAxis("Mouse Y") * orbit_Speed.y;
        } 
        spherical_Vector_Data.Zenith = Mathf.Clamp(spherical_Vector_Data.Zenith + orbit_Offset.x, orbit_Offset.y, 0f);
        float distance_ToObject = zoomValue;
        float delta_Distance = Mathf.Clamp(zoomValue, distance_ToObject, -distance_ToObject);
        spherical_Vector_Data.Length += (delta_Distance - spherical_Vector_Data.Length); // how far camera is from player 

        Vector3 lookAt = target_Offset; // var to follow player
        lookAt += playerTarget.position;

        base.Update(); //parent class Orbit update call

        transform.position += lookAt;
        transform.LookAt(lookAt);

        if(zoomValue == camera_Length_Zoom)
        {
            Quaternion targetRotation = transform.rotation;
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            playerTarget.rotation = targetRotation;
        }

        camera_Position = camera_Position_Temp;
        zoomValue = camera_Length;
    }

    void handleMouseLocking()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (MouseLock.MouseLocked)
            {
                MouseLock.MouseLocked = false;
            }
            else
            {
                MouseLock.MouseLocked = true;
            }
        }
    }

} //class
