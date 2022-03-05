using UnityEngine;

[CreateAssetMenu(fileName = "DefaultWeaponScriptableObject", menuName = "ScriptableObjects/DefaultWeapon")]
public class DefaultWeaponScriptableObject : ScriptableObject
{ 
    public int fireRate = 2;

    public DefaultPlayerProjectileScriptableObject projectile;
}
