using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerProjectileScriptableObjects", menuName = "ScriptableObjects/DefaultProjectile")]
public class DefaultPlayerProjectileScriptableObject : ScriptableObject
{
    public float damage = 10f;
    public int speed = 100;
}
