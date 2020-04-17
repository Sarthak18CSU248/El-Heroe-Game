using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopPanel;
    public static Shop instance;
    void Start()
    {
        ShopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ActivateInventory();
        }
    }
    public void ActivateInventory()
    {
        if (ShopPanel.activeInHierarchy)
        {
            ShopPanel.SetActive(false);
        }
        else
        {
            ShopPanel.SetActive(true);
           
        }
    }
}
