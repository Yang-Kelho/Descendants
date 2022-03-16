using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponInventory", menuName = "Inventory/weponInventory")]
public class WeaponInventory : ScriptableObject
{
    [SerializeField]
    private int currentWeapon = 0;

    public WeaponInventorySlots[] containers = new WeaponInventorySlots[2];
    public void ReplaceWeapon(int currentWeapon, WeaponObjects _weapon)
    {
        containers[currentWeapon] = new WeaponInventorySlots(_weapon);
    }

    public void AddDefaultWeapon(WeaponObjects _weapon)
    {
        containers[0] = new WeaponInventorySlots(_weapon);
    }

    public void SwapCurrentSlot()
    {
        if (currentWeapon == 0)
        {
            currentWeapon = 1;
        }
        else if (currentWeapon == 1)
        {
            currentWeapon = 0;
        }
    }

    public int GetCurrentSlot()
    {
        return currentWeapon;
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
