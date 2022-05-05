using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthDisplay.HealthSystemStatic.AddHeart();
            Destroy(gameObject);
        }
    }
}
