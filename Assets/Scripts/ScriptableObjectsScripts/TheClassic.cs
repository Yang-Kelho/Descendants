using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "The Classic", menuName = "WeaponObjects/Sniper/The Classic")]
public class TheClassic : WeaponObjects
{

    private void Awake()
    {
        weaponType = WeaponType.sniper;

        if (RollAffix() == 10)
        {
            affix = Affixes.cursed;
        }
        else
            affix = Affixes.none;
    }

    public TheClassic()
    {
        fireRate = 0.4f;
        spread = 0;
        numOfShots = 1;
    }
}
