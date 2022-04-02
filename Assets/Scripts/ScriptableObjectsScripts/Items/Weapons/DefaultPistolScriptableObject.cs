using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPistolObject", menuName = "WeaponObjects/Pistols/DefaultPistol")]
public class DefaultPistolScriptableObject : WeaponObjects
{

    private void Awake()
    {
        weaponType = WeaponType.pistol;
        affix = Affixes.none;
    }

    public DefaultPistolScriptableObject()
    {
        fireRate = 1f;
        spread = 5f;
        numOfShots = 1;
    }

}
