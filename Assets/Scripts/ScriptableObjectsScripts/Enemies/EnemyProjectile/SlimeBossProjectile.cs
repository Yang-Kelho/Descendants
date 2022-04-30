using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SlimeBossProjectile", menuName = "ProjectileObjects/EnemyProjectiles/SlimeBossProjectile")]
public class SlimeBossProjectile : ProjectileObjects
{
    public SlimeBossProjectile()
    {
        type = Type.enemy;
        damage = 1f;
        projectileSpeed = 700;
    }
}
