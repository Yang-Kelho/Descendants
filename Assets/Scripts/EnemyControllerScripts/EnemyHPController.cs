using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPController : MonoBehaviour
{
    public float health;
    public float maxHealth;

    
    void Start()
    {
        health = maxHealth;
    }

    private void CheckDeath()
    {
        if (health < 0)
            Destroy(gameObject);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

}
