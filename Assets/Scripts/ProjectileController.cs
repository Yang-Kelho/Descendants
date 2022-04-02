using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float damageTaken;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            if (collision.GetComponent<EnemyHPController>() != null)
            {
                damageTaken = GetComponent<Projectile>().damage;
                collision.GetComponent<EnemyHPController>().takeDamage(damageTaken);
            }
            Destroy(gameObject);
        }
    }
}
