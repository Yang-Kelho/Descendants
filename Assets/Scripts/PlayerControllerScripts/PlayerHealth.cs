using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats stats;
    public RealmController rc;

    public void PlayerDamage(int damageAmount)
    {
        //Debug.Log("Player took " + damageAmount + " damage");
        HealthDisplay.HealthSystemStatic.Damage(damageAmount);
        stats.health = GetCurrentHealth();
        if (IsDead())
            Die();
    }

    public void PlayerHeal(int healAmount)
    {
        if (!HealthDisplay.HealthSystemStatic.IsFullHealth())
        {
            //Debug.Log("Player healed " + healAmount + " HP");
            HealthDisplay.HealthSystemStatic.Heal(healAmount);
            stats.health = GetCurrentHealth();
        }
    }

    public void Die()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.GetComponent<PlayerMovementController>().enabled = false;
        gameObject.GetComponent<PlayerAtkController>().enabled = false;
        if (stats.score > rc.GetHighestScore())
        {
            rc.UpdateHighestScore(stats.score);
        }
        stats.ReSet();
    }

    public bool IsDead()
    {
        return HealthDisplay.HealthSystemStatic.IsDead();
    }

    public int GetCurrentHealth()
    {
        var heartList = HealthDisplay.HealthSystemStatic.GetHeartList();
        var currentHealth = 0;
        for (int i = 0; i < heartList.Count; i++)
        {
            currentHealth += heartList[i].GetFragmentNumber();
        }
        return currentHealth;
    }

    private void OnApplicationQuit()
    {
        stats.ReSet();
    }
}
