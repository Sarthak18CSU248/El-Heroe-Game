using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Status : MonoBehaviour
{
    private GameObject Shop_Panel;

    // Start is called before the first frame update
    void Start()
    {
        Shop_Panel= GameObject.Find("Inventory");
        Shop_Panel.SetActive(false);
        //GameObject.FindGameObjectWithTag("Shop").GetComponent<Button>().onClick.AddListener(Panel_Active);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Invoke("Panel_Active", 0f);
        }
    }
    public void Panel_Active()

    {
        if (Shop_Panel.activeInHierarchy)
            Shop_Panel.SetActive(false);
        else
            Shop_Panel.SetActive(true);
        //GameObject.Find("Inventory").SetActive(true); 
    }
}
