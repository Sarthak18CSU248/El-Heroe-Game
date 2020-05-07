using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] PlayerSwords;
    [SerializeField]private PlayerAttack playerAttack;
    public static PlayerStatus instance;
    private int choice=0;
    private void Awake()
    {
        instance = this;
        if (ES3.KeyExists("SwordChoice", "Saved Files/GameData.es3"))
            choice = ES3.Load<int>("SwordChoice", "Saved Files/GameData.es3");
        else
            ES3.Save<int>("SwordChoice",choice,"Saved Files/GameData.es3");

        playerAttack = GameObject.Find("Player Attack Point").GetComponent<PlayerAttack>();

        ChangeSword(choice);
    }
    public void ChangeSword(int choice)
    {
        for (int i = 0; i < PlayerSwords.Length; i++)
        {
            PlayerSwords[i].SetActive(false);
        }

        PlayerSwords[choice].SetActive(true);

        if(choice == 0)
        {
            playerAttack.DamageValue(15);
        }
        else if (choice==1)
        {
            playerAttack.DamageValue(40);
        }
        else
        {
            playerAttack.DamageValue(65);
        }
    }


}//class
