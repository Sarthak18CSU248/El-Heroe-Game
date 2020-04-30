using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    private Text money;
    private int currentCoins = 20000;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        money = gameObject.GetComponent<Text>();
        money.text = "$" + Convert.ToString(currentCoins);
    }

    public void changeMonetaryStatus(int expense)
    {
        int current_target = currentCoins - expense;
        StartCoroutine(CoinDecrease(current_target));
    }
   
    IEnumerator CoinDecrease(int coins_target)
    {
        while (currentCoins != coins_target)
        {
            if (currentCoins == coins_target)
                break;
            else
            {
                currentCoins -= 1;
                yield return new WaitForSeconds(1f);
                money.text = "$"+Convert.ToString(currentCoins);

            }
        }
    }
}
