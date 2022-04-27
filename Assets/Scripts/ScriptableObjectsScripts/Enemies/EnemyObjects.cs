using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjects : ScriptableObject
{
    
    public GameObject prefab;
    public ProjectileObjects projectile;
    public bool eliteCheck;
    public float speed;
    public float maxHp;
    public int goldDropped;
    public float atkCoolDown;
    public long score;

    public bool EliteRoll()
    {
        int rand = Random.Range(1, 10);
        if (rand >= 8)
            return true;
        else
            return false;
    }
}
