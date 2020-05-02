using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCoins : MonoBehaviour
{
    [SerializeField] private Mesh chest_open;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            gameObject.GetComponent<MeshFilter>().mesh = chest_open;
        }
    }
}
