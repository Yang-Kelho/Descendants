using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerProjectileScriptableObjects", menuName = "ScriptableObjects/DefaultProjectile")]
public class DefaultPlayerProjectileScriptableObject : ScriptableObject
{
    public float damage = 10f;
    public float speed = 2f;
}
