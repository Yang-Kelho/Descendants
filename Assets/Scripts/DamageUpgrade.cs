using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    public float damageBoost = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAtkController>().player.dmgMod += damageBoost;
            Destroy(gameObject);
        }
    }
}
