﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFX : MonoBehaviour
{
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}