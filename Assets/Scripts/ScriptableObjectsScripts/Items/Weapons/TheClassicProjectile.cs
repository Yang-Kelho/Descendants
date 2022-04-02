using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TheClassicProjectile", menuName = "ProjectileObjects/SniperProjectiles/TheClassicProjectile")]
public class TheClassicProjectile : ProjectileObjects
{
    public TheClassicProjectile()
    {
        damage = 13f;
        projectileSpeed = 1f;
        bounce = false;
    }
}
