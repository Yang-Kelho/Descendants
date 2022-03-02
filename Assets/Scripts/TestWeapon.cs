using UnityEngine;

[CreateAssetMenu(fileName = "TestWeaponScriptableObject", menuName = "ScriptableObjects/TestWeapon")]
public class TestWeaponScriptableObject : ScriptableObject
{ 
    public int fireRate { get; private set; } = 2;

    public DefaultProjectileScriptableObject bullet;
}
