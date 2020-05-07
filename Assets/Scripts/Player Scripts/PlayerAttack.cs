using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.3f;
    public int damage = 0;

    private EnemyHealth enemyHealth;
    private bool collided;

    public static PlayerAttack Instance;
    // Update is called once per frame
    void Update()
    {
        CheckForDamage(); 
    }
    public void DamageValue(int damage)
    {
        this.damage = damage;
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
            enemyHealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
