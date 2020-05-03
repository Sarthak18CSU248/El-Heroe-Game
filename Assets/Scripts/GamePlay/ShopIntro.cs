using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopIntro : MonoBehaviour
{
    private GameObject introImg, nextBttn,shopEntry;
    void Start()
    {
        introImg = GameObject.Find("ShopIntro");
        nextBttn =GameObject.Find("Next Button");
        shopEntry = GameObject.Find("Shop Entry");
        introImg.SetActive(false);
        nextBttn.SetActive(false);
        shopEntry.SetActive(false);
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
            bool bonusRecieved = ES3.Load<bool>("BonusStatus","Saved Files/GameData.es3");
            //Debug.Log(bonusRecieved);
            if (!bonusRecieved)
            {
                activateIntroPanel();
            }
            else
            {
                shopEntry.SetActive(true);
                ShopSystem.instance.ActivateShop();
                GameObject Button = ShopSystem.instance.swordBtn;
                Button.SetActive(true);
            }
        }
    }
}
