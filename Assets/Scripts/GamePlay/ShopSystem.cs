using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance;
    public GameObject[] SwordChangeButton;
    public GameObject[] HealthBuyButton;
    private bool enterShop;
    private GameObject swordPanel,healthPanel,swordButton,healthButton,scroller,done_crystal, done_flarecore,coinManager,buyCrystal,buyFlarecore;
    private bool acceptBonus,buySword1,buySword2;
    [HideInInspector]public GameObject Shop;

    void Start()
    {

        if (ES3.KeyExists("BonusStatus", "Saved Files/GameData.es3"))
            acceptBonus = ES3.Load<Boolean>("BonusStatus", "Saved Files/GameData.es3");
        else
            ES3.Save<bool>("BonusStatus", false, "Saved Files/GameData.es3");

        if (ES3.KeyExists("buySword1", "Saved Files/GameData.es3"))
            buySword1 = ES3.Load<bool>("buySword1", "Saved Files/GameData.es3");
        else
            ES3.Save<bool>("buySword1",false,"Saved Files/GameData.es3");

        if (ES3.KeyExists("buySword2", "Saved Files/GameData.es3"))
            buySword2 = ES3.Load<bool>("buySword2", "Saved Files/GameData.es3");
        else
            ES3.Save<bool>("buySword2", false, "Saved Files/GameData.es3");
     
        instance = this;
        Shop = GameObject.Find("ShopPanel");
        swordPanel = GameObject.Find("SwordPanel");
        swordButton = GameObject.Find("SwordButton");
        scroller = GameObject.Find("SwordScroller");
        done_crystal = GameObject.Find("DoneCrystal");
        done_flarecore = GameObject.Find("DoneFlarecore");
        coinManager = GameObject.Find("Coin System");
        buyCrystal = GameObject.Find("BuyCrystal");
        buyFlarecore = GameObject.Find("BuyFlarecore");
        healthPanel = GameObject.Find("HealthPanel");
        healthButton = GameObject.Find("HealthButton");
        //SwordChangeButton.
        Shop.SetActive(false);
        swordPanel.SetActive(false);
        swordButton.SetActive(false);
        healthButton.SetActive(false);
        scroller.SetActive(false);
        healthPanel.SetActive(false);
        done_crystal.SetActive(buySword1);
        done_flarecore.SetActive(buySword2);
        if (buySword1)
            Destroy(buyCrystal);
        if (buySword2)
            Destroy(buyFlarecore);
    }
    void Update()
    {
        ActivateShop();   
    }
    public GameObject swordBtn
    {
        get
        {
            return swordButton;
        }
    }
    public GameObject healthBtn
    {
        get
        {
            return healthButton;
        }
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
                    healthPanel.SetActive(false);
                    swordButton.SetActive(true);
                    healthButton.SetActive(true);
                    scroller.SetActive(false);
                }
            }
        }
        if (Shop.activeInHierarchy)
        {
            swordButton.GetComponent<Button>().onClick.AddListener(ActivateSwordPanel);
            healthButton.GetComponent<Button>().onClick.AddListener(ActivateHealthPanel);
            if (swordPanel.activeInHierarchy)
            {
                foreach (GameObject btn in SwordChangeButton)
                {
                    btn.GetComponent<Button>().onClick.AddListener(BuySword);
                }

            }
            if(healthPanel.activeInHierarchy)
            {
                foreach(GameObject btn in HealthBuyButton)
                {
                    btn.GetComponent<Button>().onClick.AddListener(BuyHealth);
                }
            }

        }
    }
    public void ActivateSwordPanel()
    {
        healthPanel.SetActive(false);
        if (swordPanel.activeInHierarchy)
        {
            swordPanel.SetActive(false);
            scroller.SetActive(false);
        }
        else
            swordPanel.SetActive(true);
    }
    public void ActivateHealthPanel()
    {
        swordPanel.SetActive(false);
        if (healthPanel.activeInHierarchy)
        {
            healthPanel.SetActive(false);
            scroller.SetActive(false);
        }
        else
            healthPanel.SetActive(true);
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
            ES3.Save<bool>("BonusStatus", value, "Saved Files/GameData.es3");
            Debug.Log(value);
            
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
        ES3.Save<int>("swordChoice", swordIndex, "Saved Files/GameData.es3");
        if (swordIndex == 1)
        {
            if (!buySword1)
            {
                if (MoneyManager.instance.canShop(6700))
                {
                    Destroy(GameObject.Find("BuyCrystal"));
                    done_crystal.SetActive(true);
                    PlayerStatus.instance.ChangeSword(swordIndex);
                    StartCoroutine(CoinDecrease(6700));
                    buySword1 = true;
                    ES3.Save<bool>("buySword1", buySword1, "Saved Files/GameData.es3");
                    Debug.Log(ES3.Load<bool>("buySword1", "Saved Files/GameData.es3"));
                }
            }
            else
                PlayerStatus.instance.ChangeSword(swordIndex);
            ES3.Save<int>("EnemyDamage", 40, "Saved Files/GameData.es3");
        }
        else if (swordIndex == 2)
        {
            if (!buySword2)
            {
                if (MoneyManager.instance.canShop(15000))
                {
                    Destroy(GameObject.Find("BuyFlarecore"));
                    done_flarecore.SetActive(true);
                    PlayerStatus.instance.ChangeSword(swordIndex);
                    StartCoroutine(CoinDecrease(15000));
                    buySword2 = true;
                    ES3.Save<bool>("buySword2", buySword2, "Saved Files/GameData.es3");
                }
            }
            else
                PlayerStatus.instance.ChangeSword(swordIndex);
            ES3.Save<int>("EnemyDamage", 65, "Saved Files/GameData.es3");
        }
        else
        {
            PlayerStatus.instance.ChangeSword(swordIndex);
            ES3.Save<int>("EnemyDamage", 15, "Saved Files/GameData.es3");
        }
    }
    public void BuyHealth()
    {
        Debug.Log("Into Method");
        int buyAmount = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(buyAmount);
        int healthPercentile;
        StartCoroutine(CoinDecrease(buyAmount));
        if (buyAmount == 950)
            healthPercentile = 10;
        else if (buyAmount == 1600)
            healthPercentile = 30;
        else
            healthPercentile = 50;
        PlayerHealth.instance.BuyHealth(healthPercentile);
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

            ES3.Save<int>("AccountBalance", currBalance, "Saved Files/GameData.es3");
        }

        MoneyManager.instance.getCoins = balance;
    }
}
