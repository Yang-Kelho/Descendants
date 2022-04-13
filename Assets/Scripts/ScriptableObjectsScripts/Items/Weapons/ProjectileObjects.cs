using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileObjects : ScriptableObject
{
    public enum Type
    {
        enemy,
        player,
        environment,
    }
    public Type type;
    public GameObject projectilePrefab;
    public float damage;
    public float projectileSpeed;
    public bool bounce;
}
