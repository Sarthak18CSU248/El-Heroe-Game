using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    [HideInInspector]public Text money;
    private int currentCoins = 20000;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        money = gameObject.GetComponent<Text>();
        StartCoroutine(BonusCoin());
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

    IEnumerator BonusCoin()
    {
        int coins = 0;
        while (coins != 20000)
        {
            coins+=25;
            yield return new WaitForSeconds(0.0001f);
            money.text = "$" + Convert.ToString(coins);
        }
    }
}
