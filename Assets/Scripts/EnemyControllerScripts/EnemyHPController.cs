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

    private void Die()
    {
        Transform parent = this.transform.parent;
        int goldDropped = GetComponent<Enemy>().enemy.goldDropped;
        long score = GetComponent<Enemy>().enemy.score;
        Debug.Log("enemy dropped " + goldDropped + " gold");
        GoldDisplay.goldSystem.EarnGold(goldDropped);
        Player.increaseCurrentScore(score);
        Destroy(gameObject);
        parent.GetComponent<Room>().checkClear();
    }

    public void takeDamage(float damage)
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
            Die();
    }
}
