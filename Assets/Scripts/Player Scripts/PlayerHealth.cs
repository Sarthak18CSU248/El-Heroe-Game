using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
        public GameObject deadFX;
    public Slider player_health;

    private void Start()
    {
        player_health = GameObject.Find("HealthSlider").GetComponent<Slider>();
    }
    public void TakeDamage(float damageAmount)
    {
       
        health -= damageAmount;
        player_health.value -= damageAmount * 0.01f;
        Debug.Log("PlayerHealth");
        if(health <=0)
        {
            Instantiate(deadFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }




}//class
