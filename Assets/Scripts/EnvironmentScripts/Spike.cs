using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] int spikeDamage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered spike");
            var player = other.gameObject.GetComponent<PlayerHealth>();
            player.PlayerDamage(spikeDamage);
        }
    }
}
