using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopPanel,SwordPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            SwordPanel.SetActive(false);
        }
    }
}
