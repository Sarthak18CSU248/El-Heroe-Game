using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject[] characters;
    [HideInInspector]
    public int SelectCharacterIndex;
    public GameObject HealthOrb,MoneyUI;
    public static bool Player_Instantiate=false;
    void Awake()
    {
        MakeSingleton();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading; // called when instantiated
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading; // called when gameobject is destroyed 
    }
    void MakeSingleton()
    {
        if(instance !=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            ES3.Save<int>("default", 0, "Saved Files/GameData.es3");
            DontDestroyOnLoad(gameObject);
        }
    }
    void LevelFinishedLoading(Scene scene ,LoadSceneMode mode) 
    {
        if(scene.name != "MainMenu") // spawn player
        {
            Instantiate(HealthOrb, Vector3.zero,Quaternion.identity);
            if(scene.name!="Village")
            Instantiate(MoneyUI, Vector3.zero, Quaternion.identity);
            Vector3 pos = GameObject.FindGameObjectWithTag("SpawnPosition").transform.position;
            Instantiate(characters[SelectCharacterIndex],pos,Quaternion.identity);
            Invoke("PlaySound", 1.6f);
            Player_Instantiate = true;
        }
        if(scene.name=="Village")
        {
            AudioManager.Instance.Play("Village");
        }
        else if(scene.name =="WolfWorld")
        {
            AudioManager.Instance.Play("Wolf World");
        }
        else if (scene.name == "OrcWorld")
        {
            AudioManager.Instance.Play("Orc World");
        }
        else if (scene.name == "SkyWorld")
        {
            AudioManager.Instance.Play("Sky World");
        }
    }
    private void PlaySound()
    {
        AudioManager.Instance.Play("Explosion");
    }


}//class
