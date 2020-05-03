using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCoins : MonoBehaviour
{
    [SerializeField] private Mesh chest_open;
    private GameObject treasureOpen;
    private bool opened;
    private void Awake()
    {
        treasureOpen = GameObject.Find("Treasure Open");
        treasureOpen.SetActive(false);
    }
    private void Update()
    {
        if(opened && Input.GetKeyDown(KeyCode.O))
             gameObject.GetComponent<MeshFilter>().mesh = chest_open;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            treasureOpen.SetActive(true);
            opened = true;
            
        }
    }
}
