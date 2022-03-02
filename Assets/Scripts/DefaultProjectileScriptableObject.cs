using UnityEngine;

[CreateAssetMenu(fileName = "DefaultProjectileScriptableObjects", menuName = "ScriptableObjects/DefaultProjectile")]
public class DefaultProjectileScriptableObject : ScriptableObject
{
    public float damge{get; private set;} = 10f;
    public float speed{get; private set;} = 2f;
}
