using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    [HideInInspector]public Text money;
    private int currentCoins = 0;
    private int bonus = 20000;
    // Start is called before the first frame update
    void Start()
    {
        if (ES3.KeyExists("AccountBalance","Saved Files/GameData.es3"))
        {
            currentCoins = ES3.Load<int>("AccountBalance", "Saved Files/GameData.es3");
        }
        else
        {
            ES3.Save<int>("AccountBalance", 0);
        }
        Debug.Log(currentCoins);
        instance = this;
        money = gameObject.GetComponent<Text>();
        money.text = "$" + Convert.ToString(currentCoins);
    }
    public int getCoins
    {
        get
        {
            return currentCoins;
        }
        set
        {
            currentCoins = value;
        }
        
    }
    public bool canShop(int expense)
    {
        if (expense <= currentCoins)
        {
            return true;
        }
        else
            return false;
    }
    public void BonusCoinsUpdate()
    {
        StartCoroutine(BonusCoin());
    }

    IEnumerator BonusCoin()
    {
        int coins = 0;
        while (coins != bonus)
        {
            coins+=100;
            yield return new WaitForSeconds(0.0001f);
            money.text = "$" + Convert.ToString(coins);
            currentCoins = coins;
        }
        ES3.Save<int>("AccountBalance", currentCoins,"Saved Files/GameData.es3");
        ShopSystem.instance.setBonusStatus = true;
    }
}
