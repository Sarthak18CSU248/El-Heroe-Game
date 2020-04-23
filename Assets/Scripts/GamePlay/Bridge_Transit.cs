using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Transit : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(44.31171f, 10.95034f, 112.2168f);
        }
    }
}
