using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorld : MonoBehaviour
{

    public GameObject LoadButton;
    public static OtherWorld instance;
    public GameObject Portal_Effect;
    private GameObject portal;
    public bool portalIsActive=false;
    private GameObject VillagePortal, BridgePortal;
    private bool key1, key2,level1,level2;

    private void Start()
    {
        instance = this;
        VillagePortal = GameObject.Find("BridgePortal");
        if (!ES3.KeyExists("Key1", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Key1", false, "Saved Files/GameData.es3");
        else
            key1 = ES3.Load<bool>("Key1", "Saved Files/GameData.es3");

        if (!ES3.KeyExists("Key2", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Key2", false, "Saved Files/GameData.es3");
        else
            key2 = ES3.Load<bool>("Key2", "Saved Files/GameData.es3");

        if(!ES3.KeyExists("Level1", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Level1", false, "Saved Files/GameData.es3");
        else
            level1 = ES3.Load<bool>("Level1", "Saved Files/GameData.es3");

        if (!ES3.KeyExists("Level2", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Level2", false, "Saved Files/GameData.es3");
        else
            level2 = ES3.Load<bool>("Level2", "Saved Files/GameData.es3");


        Debug.Log("Key1 " + key1);
        Debug.Log("Key2 " + key2);
    }
    public void Portal(string name)
    {
        portal = Instantiate(Portal_Effect);
        portal.transform.localScale = new Vector3(0.65263f, 0.6526299f, 0.6526299f);
        portal.SetActive(true);

        if (name == "WolfWorld")
        {
            if (!level1 && MoneyManager.instance.canShop(7000))
            {
                ES3.Save<int>("AccountBalance", MoneyManager.instance.getCoins - 7000, "Saved Files/GameData.es3");
                MoneyManager.instance.UpdateTxtUI();
                portal.transform.SetParent(GameObject.FindGameObjectWithTag("WolfWorld").transform);
                portal.transform.position = new Vector3(62.93052f, 11.55f, 129.6711f);
                StartCoroutine(LoadLevel(name));
            }
            else if (level1)
            {
                portal.transform.SetParent(GameObject.FindGameObjectWithTag("WolfWorld").transform);
                portal.transform.position = new Vector3(62.93052f, 11.55f, 129.6711f);
                StartCoroutine(LoadLevel(name));
            }
        }
        else if (name == "OrcWorld")
        {
            if (key1)
            {
                if (!level2 && MoneyManager.instance.canShop(8800))
                {
                    ES3.Save<int>("AccountBalance", MoneyManager.instance.getCoins - 8800, "Saved Files/GameData.es3");
                    MoneyManager.instance.UpdateTxtUI();
                    portal.transform.SetParent(GameObject.FindGameObjectWithTag("OrcWorld").transform);
                    portal.transform.position = new Vector3(67.08f, 11.55f, 128.53f);
                    StartCoroutine(LoadLevel(name));
                }
                else if (level2)
                {
                    portal.transform.SetParent(GameObject.FindGameObjectWithTag("OrcWorld").transform);
                    portal.transform.position = new Vector3(67.08f, 11.55f, 128.53f);
                    StartCoroutine(LoadLevel(name));
                }
            }
        }
        else
        {
            if (key2 && MoneyManager.instance.canShop(10000))
            {
                ES3.Save<int>("AccountBalance", MoneyManager.instance.getCoins - 10000, "Saved Files/GameData.es3");
                MoneyManager.instance.UpdateTxtUI();
                portal.transform.SetParent(GameObject.FindGameObjectWithTag("SkyWorld").transform);
                portal.transform.position = new Vector3(70.73f, 11.55f, 127.03f);
                StartCoroutine(LoadLevel(name));
            }
        }
    }
    IEnumerator LoadLevel(string name)
    {
        yield return new WaitForSeconds(2.5f);
        SceneLoader.instance.LoadScreen(name);
    }
    private void OnTriggerEnter(Collider target)
    {
        if(target.tag=="Player")
        {
            LoadButton.SetActive(true);
            portalIsActive = true;
        }
    }
    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Portal"));
            LoadButton.SetActive(false);
            portalIsActive = false;
        }
    }


}//class
