using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponInventory", menuName = "Inventory/weponInventory")]
public class WeaponInventory : ScriptableObject
{
    [SerializeField]
    private int currentWeapon = 0;

    public WeaponInventorySlots[] containers = new WeaponInventorySlots[2];
    public void SetToZero()
    {
        currentWeapon = 0;
    }
    public void AddWeapon(WeaponObjects _weapon)
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

    public WeaponObjects GetCurrentWeapon()
    {
        var dropped = containers[currentWeapon].weapons;
        return dropped;
    }

    public int GetCurrentSlot()
    {
        return currentWeapon;
    }

    public void Clear()
    {
        for (int i = 0; i < containers.Length; i++)
        {
            containers[i] = null;
        }
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
