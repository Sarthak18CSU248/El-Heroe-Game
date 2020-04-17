using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] PlayerSwords;
    public GameObject SwordPanel,SwordScroller,SwordButton;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject[] SwordChangeButton = GameObject.FindGameObjectsWithTag("SwordBtn");
        foreach (GameObject btn in SwordChangeButton)
        {
            btn.GetComponent<Button>().onClick.AddListener(ChangeSword);
        }
        SwordPanel.SetActive(false);
        SwordScroller.SetActive(false);
        SwordButton.GetComponent<Button>().onClick.AddListener(ActivateSwordPanel);
    }
    public void ActivateSwordPanel()
    { 
            SwordPanel.SetActive(true);  
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
