using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance;
    private bool enterShop;
    private GameObject swordPanel,swordButton,scroller,done_crystal, done_flarecore,coinManager;
    private bool acceptBonus;
    [HideInInspector]public GameObject Shop;
    void Start()
    {
        instance = this;
        Shop = GameObject.Find("ShopPanel");
        swordPanel = GameObject.Find("SwordPanel");
        swordButton = GameObject.Find("SwordButton");
        scroller = GameObject.Find("SwordScroller");
        done_crystal = GameObject.Find("DoneCrystal");
        done_flarecore = GameObject.Find("DoneFlarecore");
        coinManager = GameObject.Find("Coin System");
        Shop.SetActive(false);
        swordPanel.SetActive(false);
        swordButton.SetActive(false);
        scroller.SetActive(false);
        done_crystal.SetActive(false);
        done_flarecore.SetActive(false);

    }
    void Update()
    {
        ActivateShop();   
    }
    public void ActivateShop()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canShop())
            {
                if (Shop.activeInHierarchy)
                {
                    Shop.SetActive(false);
                    MouseLock.MouseLocked = true;
                }
                else
                {
                    Shop.SetActive(true);
                    MouseLock.MouseLocked = false;
                    swordPanel.SetActive(false);
                    swordButton.SetActive(true);
                    scroller.SetActive(false);
                }
            }
        }
        if (Shop.activeInHierarchy)
        {
            swordButton.GetComponent<Button>().onClick.AddListener(ActivateSwordPanel);
            if (swordPanel.activeInHierarchy)
            {
                GameObject[] SwordChangeButton = GameObject.FindGameObjectsWithTag("SwordBtn");
                foreach (GameObject btn in SwordChangeButton)
                {
                    btn.GetComponent<Button>().onClick.AddListener(BuySword);
                }

            }

        }
    }
    public void ActivateSwordPanel()
    {
        if (swordPanel.activeInHierarchy)
        {
            swordPanel.SetActive(false);
            scroller.SetActive(false);
        }
        else
            swordPanel.SetActive(true);
    }
    private bool canShop()
    {
        return enterShop;
    }
    public bool setBonusStatus
    {
        get
        {
            return acceptBonus;
        }
        set
        {
            acceptBonus = value;
        }
    }
    public bool setShopStatus
    {
        get
        {
            return enterShop;
        }
        set
        {
            enterShop = value;
        }
    }
    private void BuySword()
    {
        int swordIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(swordIndex);
        if (swordIndex == 1)
        {
            if (MoneyManager.instance.canShop(6700))
            {
                Destroy(GameObject.Find("BuyCrystal"));
                done_crystal.SetActive(true);
                PlayerStatus.instance.ChangeSword(swordIndex);
                StartCoroutine(CoinDecrease(6700));
            }
        }
        else if (swordIndex == 2)
        {
            if (MoneyManager.instance.canShop(15000))
            {
                Destroy(GameObject.Find("BuyFlarecore"));
                done_flarecore.SetActive(true);
                PlayerStatus.instance.ChangeSword(swordIndex);
                StartCoroutine(CoinDecrease(15000));
            }
        }
    }
    IEnumerator CoinDecrease(int coins_target)
    {
        int currBalance = MoneyManager.instance.getCoins;
        int balance = currBalance - coins_target;
        while (currBalance != balance)
        {
            if (currBalance == balance)
                break;
            else
            {
                currBalance -= 100;
                yield return new WaitForSeconds(0.001f);
                MoneyManager.instance.money.text = "$" + Convert.ToString(currBalance);

            }
        }

        MoneyManager.instance.getCoins = balance;
    }
}
