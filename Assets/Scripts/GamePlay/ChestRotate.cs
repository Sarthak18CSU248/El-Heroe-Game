using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRotate : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,0, 20*Time.deltaTime);
    }
}
