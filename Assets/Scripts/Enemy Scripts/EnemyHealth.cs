using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject deadFX;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        print("Damage");
        if(health <=0)
        {
            Instantiate(deadFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (gameObject.name == "SmallWOLF")
            {
                MoneyManager.instance.RecieveKillBonus(350);
            }
            else if (gameObject.name == "Small Orc lvl1")
            {
                MoneyManager.instance.RecieveKillBonus(550);
            }
            else
            {
                MoneyManager.instance.RecieveKillBonus(750);
            }

            Debug.Log(MoneyManager.instance.getCoins);
        }
    }

}//class


