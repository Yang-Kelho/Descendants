using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPController : MonoBehaviour
{
    private float health;
    
    void Start()
    {
        health = GetComponent<Enemy>().enemy.maxHp;
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
