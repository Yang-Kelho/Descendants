using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BoomStickProjectile", menuName = "ProjectileObjects/ShotgunProjectiles/BoomStickProjectile")]
public class BoomStickProjectile : ProjectileObjects
{
    public BoomStickProjectile()
    {
        damage = 5f;
        projectileSpeed = 0.5f;
        bounce = false;
    }

}
