using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask playerLayer;
    public float damge = 1f;
    public float radius = 0.3f;

    private PlayerHealth playerHealth;
    private bool collided;

    // Update is called once per frame
    void Update()
    {
        CheckForDamage();
    }

    void CheckForDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, playerLayer);
        foreach(Collider h in hits)
        {
            playerHealth = h.GetComponent<PlayerHealth>();
            if(playerHealth)
            {
                collided = true;
            }
        }

        if(collided)
        {
            collided = false;
            playerHealth.TakeDamage(damge);
            gameObject.SetActive(false);
        }
    }


}//class
