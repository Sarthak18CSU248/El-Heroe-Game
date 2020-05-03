using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    //public GameObject Portals;
    public GamePlayController instance;
    private bool key1, key2;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (!ES3.KeyExists("Key1", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Key1", false, "Saved Files/GameData.es3");
        else
            key1 = ES3.Load<bool>("Key1", "Saved Files/GameData.es3");

        if (!ES3.KeyExists("Key2", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Key2", false, "Saved Files/GameData.es3");
        else
            key2 = ES3.Load<bool>("Key2", "Saved Files/GameData.es3");

        /*if (!ES3.KeyExists("Key3", "Saved Files/GameData.es3"))
            ES3.Save<bool>("Key3", false, "Saved Files/GameData.es3");*/
    }
    public void LoadOtherWorld()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if(name=="Orc World" && key1==true)
            OtherWorld.instance.Portal(name);
        if(name=="Sky World" && key2==true)
            OtherWorld.instance.Portal(name);
        if(name=="Wolf World")
            OtherWorld.instance.Portal(name);
    }
    
} // class
