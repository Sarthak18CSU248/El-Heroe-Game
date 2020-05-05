using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (opened && Input.GetKeyDown(KeyCode.O))
        {
            gameObject.GetComponent<MeshFilter>().mesh = chest_open;
            if(SceneManager.GetActiveScene().name=="WolfWorld")
                MoneyManager.instance.RecieveKillBonus(5800);
            else if (SceneManager.GetActiveScene().name == "OrcWorld")
                MoneyManager.instance.RecieveKillBonus(9100);
        }
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
