using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] PlayerSwords;

    private GameObject SwordPanel;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject[] SwordChangeButton = GameObject.FindGameObjectsWithTag("SwordBtn");
        foreach (GameObject btn in SwordChangeButton)
        {
            btn.GetComponent<Button>().onClick.AddListener(ChangeSword);
        }
        SwordPanel = GameObject.Find("Sword Panel");
        //SwordPanel.SetActive(false);
        //GameObject.Find("Sword Scroller").SetActive(false);
        GameObject.Find("Sword Button").GetComponent<Button>().onClick.AddListener(ActivateSwordPanel);
    }

    public void ActivateSwordPanel()
    {
        if(SwordPanel.activeInHierarchy)
        {
            SwordPanel.SetActive(false);
            GameObject.Find("Sword Scroller").SetActive(false);
        }
        else
        {
            SwordPanel.SetActive(true);
            //GameObject.Find("Sword Scroller").SetActive(true);
        }
    }
    public void ChangeSword()
    {
        int swordIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        for (int i=0;i<PlayerSwords.Length;i++)
        {
            PlayerSwords[i].SetActive(false);
        }
        PlayerSwords[swordIndex].SetActive(true); 
    }
    

}//class
