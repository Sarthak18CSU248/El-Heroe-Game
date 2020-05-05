using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiFrostKEys : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Destroy(this.gameObject);
            if (this.gameObject.name == "OrcWorld Key")
            {
                ES3.Save<bool>("Key2", true, "Saved Files/GameData.es3");
                ES3.Save<bool>("Level1", true, "Saved Files/GameData.es3");

            }
            else if (this.gameObject.name == "WolfWorld Key")
            {
                ES3.Save<bool>("Key1", true, "Saved Files/GameData.es3");
                ES3.Save<bool>("Level2", true, "Saved Files/GameData.es3");

            }
            else
                ES3.Save<bool>("Key3", true, "Saved Files/GameData.es3");
        }
    }

}
