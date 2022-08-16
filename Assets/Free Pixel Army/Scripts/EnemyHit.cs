using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public float HP;
    public float maxHealth;
    public EnemyHealthBar healthbar;
    void Start()
    {

        healthbar.SetHealth(HP);
        healthbar.maxHealth = HP;
        
        
    }
    void Update()
    {
        if (HP <= 0)
        {
            EnemyCount.enemys += 1;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            healthbar.SetHealth(HP);
            HP -= 20f;
        }
    }
}