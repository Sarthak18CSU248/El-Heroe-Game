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
        instance = this;
        money = gameObject.GetComponent<Text>();
        money.text = "$" + Convert.ToString(currentCoins);
    }
    public int getCoins()
    {
        return currentCoins;
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
        ShopSystem.instance.setBonusStatus=true;
    }
}
