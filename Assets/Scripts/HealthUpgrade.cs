using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().stats.health += 2;
            other.GetComponent<PlayerHealth>().stats.maxHealth += 2;
            HealthDisplay.HealthSystemStatic.AddHeart();
            Destroy(gameObject);
        }
    }
}
