using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour
{
    public float speedBoost = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovementController>().player.speed += speedBoost;
            Destroy(gameObject);
        }
    }
}
