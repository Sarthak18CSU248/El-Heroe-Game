using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopIntro : MonoBehaviour
{
    private GameObject introImg, nextBttn;
    void Start()
    {
        introImg = GameObject.Find("ShopIntro");
        nextBttn =GameObject.Find("Next Button");
        introImg.SetActive(false);
        nextBttn.SetActive(false);
    }
    private void Update()
    {
        nextBttn.GetComponent<Button>().onClick.AddListener(activateShop);
    }
    private void activateIntroPanel()
    {
        introImg.SetActive(true);
        nextBttn.SetActive(true);
    }
    public void activateShop()
    {
        introImg.SetActive(false);
        nextBttn.SetActive(false);
        ShopSystem.instance.Shop.SetActive(true);
        ShopSystem.instance.ActivateShop();
        MoneyManager.instance.BonusCoinsUpdate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShopSystem.instance.setShopStatus = true;
            if (!ShopSystem.instance.setBonusStatus)
            { 
                activateIntroPanel();
            }
            else
                ShopSystem.instance.ActivateShop();
        }
    }
}
