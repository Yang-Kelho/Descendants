using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BurstRifleProjectile", menuName = "ProjectileObjects/MachineGunProjectiles/BurstRifleProjectile")]
public class BurstRifleProjectile : ProjectileObjects
{
    public BurstRifleProjectile()
    {
        damage = 5f;
        projectileSpeed = 0.5f;
        bounce = false;
    }

}
