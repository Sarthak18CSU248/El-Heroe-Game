using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public Sprite[] Loading_Images;
    [HideInInspector]public GameObject LoadingImage, LoadingImage_Canvas;

    private void Awake()
    {
        MakeSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
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
    public void LoadScreen(string sceneName)
    {
        int num = Random.Range(0, Loading_Images.Length);
        LoadingImage.GetComponent<Image>().sprite = Loading_Images[num];
        StartCoroutine(Load_Scene(sceneName));
    }
    IEnumerator Load_Scene(string sceneName)
    {
        LoadingImage_Canvas.SetActive(true);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(2f);
        LoadingImage.GetComponent<Image>().sprite = null;
        LoadingImage_Canvas.SetActive(false);
    }

}//class
