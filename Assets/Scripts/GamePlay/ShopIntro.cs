using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopIntro : MonoBehaviour
{
    private GameObject introImg, nextBttn;
    void Start()
    {
        introImg = GameObject.Find("ShopIntro");
        nextBttn =GameObject.Find("Next Button");
        introImg.SetActive(false);
        nextBttn.SetActive(false);
    }
    private void activateIntroPanel()
    {
        introImg.SetActive(false);
        nextBttn.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.tag == "Player")
        {
            if (ShopSystem.instance.setBonusStatus == false)
                activateIntroPanel();
            else
                ShopSystem.instance.Update();
        }
    }
}
