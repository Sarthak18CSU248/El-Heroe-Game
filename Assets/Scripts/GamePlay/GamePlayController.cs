using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    //public GameObject Portals;
    public GamePlayController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void LoadOtherWorld()
    {
        AudioManager.Instance.Stop("Village");
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        OtherWorld.instance.Portal(name);
    }
    
} // class
