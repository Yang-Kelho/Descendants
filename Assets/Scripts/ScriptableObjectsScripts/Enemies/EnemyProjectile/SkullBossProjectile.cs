using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkullBossProjectile", menuName = "ProjectileObjects/EnemyProjectiles/SkullBossProjectile")]
public class SkullBossProjectile : ProjectileObjects
{
    public SkullBossProjectile()
    {
        type = Type.enemy;
        damage = 0f;
        projectileSpeed = 550;
    }
}
