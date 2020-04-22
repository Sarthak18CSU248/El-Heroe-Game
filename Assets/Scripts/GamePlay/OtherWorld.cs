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
    private void Start()
    {
        instance = this;
        VillagePortal = GameObject.Find("BridgePortal");
        
    }
    private void Update()
    {
        
    }
    public void Portal(string name)
    {
        portal = Instantiate(Portal_Effect);
        portal.transform.localScale = new Vector3(0.65263f, 0.6526299f, 0.6526299f);
        portal.SetActive(true);

        if (name == "WolfWorld")
        {
            portal.transform.SetParent(GameObject.FindGameObjectWithTag("WolfWorld").transform);
            portal.transform.position = new Vector3(62.93052f, 11.55f, 129.6711f);
            StartCoroutine(LoadLevel(name));
        }
        else if (name == "OrcWorld")
        {
            portal.transform.SetParent(GameObject.FindGameObjectWithTag("OrcWorld").transform);
            portal.transform.position = new Vector3(67.08f, 11.55f, 128.53f);
            StartCoroutine(LoadLevel(name));
        }
        else
        {
            portal.transform.SetParent(GameObject.FindGameObjectWithTag("SkyWorld").transform);
            portal.transform.position = new Vector3(70.73f, 11.55f, 127.03f);
            StartCoroutine(LoadLevel(name));
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
            //Destroy(GameObject.FindGameObjectWithTag("Portal"));
        }
    }


}//class
