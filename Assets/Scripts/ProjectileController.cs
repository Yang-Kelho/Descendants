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
        {
            if (collision.CompareTag("Enemies") && collision.isTrigger)
            {
                damageTaken = GetComponent<Projectile>().damage;
                collision.GetComponent<EnemyHPController>().takeDamage(damageTaken);
                Destroy(gameObject);
            }
        }
        else if (type == ProjectileObjects.Type.enemy)
        {
            if (collision.CompareTag("Player"))
            {
                if (!(collision.gameObject.GetComponent<PlayerHealth>().IsDead()))
                {
                    damageTaken = GetComponent<Projectile>().damage;
                    collision.gameObject.GetComponent<PlayerHealth>().PlayerDamage((int)damageTaken);
                    Destroy(gameObject);
                }
            }
        }
        if (collision.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
