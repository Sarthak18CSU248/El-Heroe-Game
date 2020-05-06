using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village_Transit : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = new Vector3(43.41804f,0.9521687f,90.66909f);
        }
    }
    

    //other.transform.position = new Vector3(44.31171f,10.95034f,112.2168f);
}
