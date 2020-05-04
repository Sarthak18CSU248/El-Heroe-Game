using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayer;

    private float damage;
    public float radius = 0.3f;

    private EnemyHealth enemyHealth;
    private bool collided;

    private void Start()
    {
        if (ES3.KeyExists("EnemyDamage", "Saved Files/GameData.es3"))
            damage = ES3.Load<int>("EnemyDamage", "Saved Files/GameData.es3");
        else
            ES3.Save<int>("EnemyDamage", 15, "Saved Files/GameData.es3");
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
            enemyHealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
