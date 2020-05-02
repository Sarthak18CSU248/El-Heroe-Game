using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] PlayerSwords;
    public static PlayerStatus instance;
    private void Awake()
    {
        instance = this;
    }
    public void ChangeSword(int choice)
    {
        for (int i = 0; i < PlayerSwords.Length; i++)
        {
            PlayerSwords[i].SetActive(false);
        }

        PlayerSwords[choice].SetActive(true);
    }


}//class
