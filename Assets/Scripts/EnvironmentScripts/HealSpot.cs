using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpot : MonoBehaviour
{
    [SerializeField] int healAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touched healspot");
            var player = other.gameObject.GetComponent<PlayerHealth>();
            player.PlayerHeal(healAmount);
        }
    }
}
