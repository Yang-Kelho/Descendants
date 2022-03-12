using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponInventory", menuName = "Inventory/weponInventory")]
public class Inventory : ScriptableObject
{
    public WeaponInventorySlots[] containers = new WeaponInventorySlots[2];
    public void ReplaceWeapon(int currentSlot, WeaponObjects _weapon)
    {
        containers[currentSlot] = new WeaponInventorySlots(_weapon);
    }

    public void AddDefaultWeapon(WeaponObjects _weapon)
    {
        containers[0] = new WeaponInventorySlots(_weapon);
    }

    [System.Serializable]
    public class WeaponInventorySlots
    {
        public WeaponObjects weapons;
        public WeaponInventorySlots(WeaponObjects _weapon)
        {
            weapons = _weapon;
        }
    }
    
}
