using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance;
    private Slider slider;
    private float fillSpeed = 0.02f;
    private float targetProgress = 0;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ProgressUpdate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
    }
    public double SliderValue
    {
        get
        {
            return slider.value;
        }
        set
        {
            slider.value = (float)value;
        }
    }
    public void ProgressUpdate(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
