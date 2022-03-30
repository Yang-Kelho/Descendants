using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boom Stick", menuName = "WeaponObjects/Shotgun/BoomStick")]
public class BoomStick : WeaponObjects
{
    private void Awake()
    {
        weaponType = WeaponType.shotGun;
        
        if (RollAffix() == 10)
        {
            affix = Affixes.cursed;
        }
        else
            affix = Affixes.none;
    }

    public BoomStick()
    {
        fireRate = 1.5f;
        spread = 4f;
        numOfShots = 3;
    }
}
