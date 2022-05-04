using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPController : MonoBehaviour
{
    private float health;
    private AudioSource damageSound;
    public PlayerStats stats;
    
    void Start()
    {
        health = GetComponent<Enemy>().enemy.maxHp;
        damageSound = GetComponent<AudioSource>();
    }

    private void Die()
    {
        SoundManager sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        Transform parent = this.transform.parent;
        int goldDropped = GetComponent<Enemy>().enemy.goldDropped;
        long score = GetComponent<Enemy>().enemy.score;
        Debug.Log("enemy dropped " + goldDropped + " gold");
        GoldDisplay.goldSystem.EarnGold(goldDropped);
        stats.score += score;
        Destroy(gameObject);
        if (this.gameObject.CompareTag("Boss"))
        {
            sm.PlaySound("deathBoss");
            Staircase sc = GameObject.FindObjectsOfType<Staircase>(true)[0];
            sc.gameObject.SetActive(true);
        }
        else
        {
            sm.PlaySound("deathBoss");
            parent.GetComponent<Room>().checkClear();
        }
    }

    public void TakeDamage(float damage)
    {
        if (health > damage)
        {
            damageSound.Play();
            health -= damage;
        }
        else
            Die();
    }
}
