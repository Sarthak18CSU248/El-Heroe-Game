using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] PlayerSwords;
    private GameObject Shop,ShopLogo,swordPanel,swordButton,scroller,buy_Crystal,done_crystal, done_flarecore;
    public static int Sword_Choice;
    
    void Start()
    {
        Shop = GameObject.Find("ShopPanel");
        swordPanel = GameObject.Find("SwordPanel");
        swordButton = GameObject.Find("SwordButton");
        scroller = GameObject.Find("SwordScroller");
        done_crystal = GameObject.Find("DoneCrystal");
        done_flarecore = GameObject.Find("DoneFlarecore");
        ShopLogo = GameObject.Find("ShopLogo");
        Shop.SetActive(false);
        swordPanel.SetActive(false);
        swordButton.SetActive(false);
        scroller.SetActive(false);
        done_crystal.SetActive(false);
        done_flarecore.SetActive(false);
        ShopLogo.SetActive(false);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (Shop.activeInHierarchy)
            {
                Shop.SetActive(false);
                ShopLogo.SetActive(false);
                MouseLock.MouseLocked = true;
            }
            else
            {
                Shop.SetActive(true);
                MouseLock.MouseLocked = false;
                swordPanel.SetActive(false);
                swordButton.SetActive(true);
                scroller.SetActive(false);
                ShopLogo.SetActive(true);
            }
        }
        if(Shop.activeInHierarchy)
        {
            swordButton.GetComponent<Button>().onClick.AddListener(ActivateSwordPanel);
            if (swordPanel.activeInHierarchy)
            {
                GameObject[] SwordChangeButton = GameObject.FindGameObjectsWithTag("SwordBtn");
                foreach (GameObject btn in SwordChangeButton)
                {
                    btn.GetComponent<Button>().onClick.AddListener(ChangeSword);
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
    public void ChangeSword()
    {
        int swordIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        if(swordIndex==1)
        {
            if (MoneyManager.instance.canShop(6700))
            {
                Destroy(GameObject.Find("BuyCrystal"));
                done_crystal.SetActive(true);
                StartCoroutine(CoinDecrease(6700));
            }
        }
        else if(swordIndex==2)
        {
            if (MoneyManager.instance.canShop(15000))
            {
                Destroy(GameObject.Find("BuyFlarecore"));
                done_flarecore.SetActive(true);
                StartCoroutine(CoinDecrease(15000));
            }
        }
        for (int i=0;i<PlayerSwords.Length;i++)
        {
            PlayerSwords[i].SetActive(false);
        }
        PlayerSwords[swordIndex].SetActive(true);
        Sword_Choice = swordIndex;
        Debug.Log(Sword_Choice);
    }
    IEnumerator CoinDecrease(int coins_target)
    {
        int currBalance = MoneyManager.instance.getCoins();
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
    }


}//class
