using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    private int health = 50;
    public GameObject deadFX;
    public Slider player_health;

    private void Start()
    {
        instance = this;
       ES3.DeleteKey("PlayerHealth", "Saved Files/GameData.es3");

        if (ES3.KeyExists("PlayerHealth", "Saved Files/GameData.es3"))
            health = ES3.Load<int>("PlayerHealth", "Saved Files/GameData.es3");
        else
            ES3.Save<int>("PlayerHealth",health,"Saved Files/GameData.es3");

        player_health = GameObject.Find("HealthSlider").GetComponent<Slider>();
        player_health.value = health * 0.01f;
    }

    public float getSetHealth
    {
        get
        {
            return health;
        }
        set
        {
            health = (int)value;
            Invoke("BuyHealth",0f);
        }
    }
    public void TakeDamage(int damageAmount)
    {
       
        health -= damageAmount;
        ES3.Save<int>("PlayerHealth",health,"Saved Files/GameData.es3");
        player_health.value -= damageAmount * 0.01f;
        if(health <=0)
        {
            ES3.DeleteFile("Saved Files/GameData.es3");
            Instantiate(deadFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void BuyHealth()
    {
        player_health.value = health * 0.01f;
        Debug.Log("Into Buy Health  "+health);
        Debug.Log(player_health.value);
        ES3.Save<int>("PlayerHealth", health, "Saved Files/GameData.es3");
    }




}//class
