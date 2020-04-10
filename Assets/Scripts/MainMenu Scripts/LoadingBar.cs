using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingBar : MonoBehaviour
{

    private Slider slider;
    private float fillSpeed = 0.02f;
    private float targetProgress = 0;
    [SerializeField] private GameObject Loading_Img;
    private int number;
    public Sprite[] images;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        number = UnityEngine.Random.Range(0, images.Length);
    }
    // Start is called before the first frame update
    void Start()
    {
        ProgressUpdate(1f);
        InvokeRepeating("ChangeNumber", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(number);
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
             number = UnityEngine.Random.Range(0, images.Length);
           
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            Loading_Img.GetComponent<Image>().sprite = null;
        }
    }
    public void ChangeNumber()
    {
        StartCoroutine(ChangeSprites(number));
    }
    public void ProgressUpdate(float newProgress)
    { 
        targetProgress = slider.value + newProgress;
    }
    IEnumerator ChangeSprites(int i)
    {
        Loading_Img.GetComponent<Image>().sprite = images[i];
        yield return new WaitForSeconds(10f);
        //Loading_Img.GetComponent<Image>().sprite = images[i];

    }
}
