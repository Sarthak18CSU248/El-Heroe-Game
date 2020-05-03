using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStructure : MonoBehaviour
{
    public static SaveStructure instance;
    void Start()
    {
        ES3.Save<int>("AccountBalance", 0);
        ES3.Save<bool>("BonusStatus", false);    
    }
}
