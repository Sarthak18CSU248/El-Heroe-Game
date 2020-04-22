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
    public GameObject Inventory;
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
            DontDestroyOnLoad(gameObject);
        }
    }
    void LevelFinishedLoading(Scene scene ,LoadSceneMode mode) 
    {
        if(scene.name != "MainMenu") // spawn player
        {
            Instantiate(Inventory, Vector3.zero,Quaternion.identity);
            Vector3 pos = GameObject.FindGameObjectWithTag("SpawnPosition").transform.position;
            Instantiate(characters[SelectCharacterIndex],pos,Quaternion.identity);
            Player_Instantiate = true;
        }
    }


}//class
