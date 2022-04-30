using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int health = 6;
    public int gold = 0;
    public int maxHealth = 6;

    public void SetHealth(int _health)
    {
        _health = health;
    }

    public void ReSet()
    {
        health = 6;
        gold = 0;
        maxHealth = 6;
    }

       
}
