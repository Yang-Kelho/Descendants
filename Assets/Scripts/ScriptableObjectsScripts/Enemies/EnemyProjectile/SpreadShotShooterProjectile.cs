using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpreadShotShooterProjectile", menuName = "ProjectileObjects/EnemyProjectiles/SpreadShotShooterProjectile")]
public class SpreadShotShooterProjectile : ProjectileObjects
{
    public SpreadShotShooterProjectile()
    {
        type = Type.enemy;
        damage = 2f;
        projectileSpeed = 500;
    }
}
