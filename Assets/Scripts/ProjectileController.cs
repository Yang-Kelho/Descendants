using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float damageTaken;

    void OnTriggerEnter2D(Collider2D collision)
    {
        var type = GetComponent<Projectile>().projectile.type;
        if (type == ProjectileObjects.Type.player)
            if (collision.CompareTag("Enemies"))
            {
                if (collision.GetComponent<EnemyHPController>() != null)
                {
                    damageTaken = GetComponent<Projectile>().damage;
                    collision.GetComponent<EnemyHPController>().takeDamage(damageTaken);
                }
                Destroy(gameObject);
            }
        // Fill in health manager for player
        //      else if (type == ProjectileObjects.Type.enemy)
        //      {
        //          if (collision.CompareTag("player"))
        //          {
        //
        //               
        //
        //          }
        //          Destroy(gameObject);
        //       }
    }
}
