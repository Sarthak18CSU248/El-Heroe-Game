using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornado : MonoBehaviour
{
    public float speed = 250f;
    public float maxSpeed = 350f;
    public float speed_Multiplier = 1f;

    private float lifetime = 4f;
    private Rigidbody myBody;

    private Transform player;
    private Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.forward;
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        speed += speed_Multiplier;
        if(speed>maxSpeed)
        {
            speed = maxSpeed;
        }
        myBody.velocity = speed * Time.deltaTime * direction;
    }

}//class
