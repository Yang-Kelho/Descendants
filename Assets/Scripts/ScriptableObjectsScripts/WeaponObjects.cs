using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{ 
    pistol,
    shotGun,
    sniper,
    machineGun,
    laser
}

public enum Affixes
{ 
    cursed,
    none
}

public abstract class WeaponObjects : ScriptableObject
{
    public GameObject weaponPrefab;
    public WeaponType weaponType;
    public Affixes affix;
    public int numOfShots;
    public float fireRate;
    public float spread;
    [TextArea(10, 10)]
    public string tooltip;
    [TextArea(20, 10)]
    public string description;
    public ProjectileObjects projectile;

    public int RollAffix()
    {
        int rand = Random.Range(1, 10);
        return rand;
    }
}

 
