using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToVillage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            SceneLoader.instance.LoadScreen("Village");
        }
    }
}
