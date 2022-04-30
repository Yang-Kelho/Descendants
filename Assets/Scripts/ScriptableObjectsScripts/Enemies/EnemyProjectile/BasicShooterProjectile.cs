using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicShooterProjectile", menuName = "ProjectileObjects/EnemyProjectiles/BasicShooterProjectile")]
public class BasicShooterProjectile : ProjectileObjects
{
    public BasicShooterProjectile()
    {
        type = Type.enemy;
        damage = 2f;
        projectileSpeed = 800;
    }
}
