using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject deadFX;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        print("Damage");
        if(health <=0)
        {
            Instantiate(deadFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (gameObject.name == "SmallWOLF")
                MoneyManager.instance.getCoins += 350;
            else if (gameObject.name == "Small Orc lvl1")
                MoneyManager.instance.getCoins += 510;
            else
                MoneyManager.instance.getCoins += 750;

            Debug.Log(MoneyManager.instance.getCoins);
        }
    }

}//class


