using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damageTaken;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyHPController>() != null)
            {
                collision.GetComponent<EnemyHPController>().takeDamage(damageTaken);
            }
            Destroy(gameObject);
        }
    }
}
