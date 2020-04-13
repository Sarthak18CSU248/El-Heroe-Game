using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorld : MonoBehaviour
{

    public GameObject LoadButton;
    private void OnTriggerEnter(Collider target)
    {
        if(target.tag=="Player")
        {
            LoadButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            LoadButton.SetActive(false);
        }
    }


}//class
