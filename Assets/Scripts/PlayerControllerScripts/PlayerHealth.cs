using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void PlayerDamage(int damageAmount)
    {
        Debug.Log("Player took " + damageAmount + " damage");
        HealthDisplay.HealthSystemStatic.Damage(damageAmount);
        if (IsDead())
            Die();
    }

    public void PlayerHeal(int healAmount)
    {
        if (!HealthDisplay.HealthSystemStatic.IsFullHealth())
        {
            Debug.Log("Player healed " + healAmount + " HP");
            HealthDisplay.HealthSystemStatic.Heal(healAmount);
        }
    }

    public void Die()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.GetComponent<PlayerMovementController>().enabled = false;
    }

    public bool IsDead()
    {
        return HealthDisplay.HealthSystemStatic.IsDead();
    }
}
