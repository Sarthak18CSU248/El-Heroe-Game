using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int enemy_damage = 20;
    public float radius = 2f;

    private EnemyHealth enemyHealth;
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDamage();
    }
    void CheckForDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach(Collider h in hits)
        {
            enemyHealth = h.GetComponent<EnemyHealth>();
            if(enemyHealth)
            {
                collided = true;
            }

        }
        if(collided)
        {
            collided = false;
            enemyHealth.TakeDamage(enemy_damage);
            Destroy(gameObject);
        }
    }



}//class
