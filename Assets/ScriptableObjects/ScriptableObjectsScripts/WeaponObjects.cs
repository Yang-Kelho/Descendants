using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{ 
    pistol,
    shotGun,
    sniper,
    machineGun,
    Laser
}

public enum Affixes
{ 
    greedy,
    berserk,
    risky,
    none
}

public enum ShotType
{ 
    singleShot,
    multiShot,
    continous
}

public abstract class WeaponObjects : ScriptableObject
{
    public GameObject weaponPrefab;
    public WeaponType weaponType;
    public Affixes affix;
    public ShotType shotType;
    public float fireRate;
    public float spread;
    [TextArea(10, 10)]
    public string tooltip;
    [TextArea(20, 10)]
    public string description;
    public ProjectileObjects projectile;
}
