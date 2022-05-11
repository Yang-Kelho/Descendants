using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Burst Rifle", menuName = "WeaponObjects/MachineGun/BurstRifle")]
public class BurstRifle : WeaponObjects
{
    public void OnEnable()
    {
        weaponType = WeaponType.machineGun;

        if (RollAffix() == 10)
        {
            affix = Affixes.cursed;
        }
        else
            affix = Affixes.none;
    }

    public BurstRifle()
    {
        fireRate = 1.5f;
        spread = 4f;
        numOfShots = 3;
    }
}
