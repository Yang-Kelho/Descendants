using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int health = 6;
    public int gold = 0;
    public int maxHealth = 6;
    public long score = 0;
    public float speed = 300;
    public float dmgMod = 0;

    public void ReSet()
    {
        health = 6;
        gold = 0;
        maxHealth = 6;
        score = 0;
        speed = 300;
        dmgMod = 0;
    }
}
