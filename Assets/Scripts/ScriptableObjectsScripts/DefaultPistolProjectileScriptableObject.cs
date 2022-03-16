using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPistolProjectile", menuName = "ProjectileObjects/PistolProjectiles/DefaultPistolProjectile")]
public class DefaultPistolProjectileScriptableObject : ProjectileObjects
{
    public DefaultPistolProjectileScriptableObject()
    {
        damage = 5f;
        projectileSpeed = 10f;
        bounce = false;
    }
}
