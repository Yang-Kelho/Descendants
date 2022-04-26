using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "weaponInventory", menuName = "Inventory/weponInventory")]
public class WeaponInventory : ScriptableObject
{
    [SerializeField]
    private int currentWeapon = 0;

    public WeaponInventorySlots[] containers = new WeaponInventorySlots[2] {null, null};
    public void SetToZero()
    {
        currentWeapon = 0;
    }
    public void AddWeapon(WeaponObjects _weapon)
    {
        int slots = CheckEmptySlot();
        if (slots < 2)
            containers[slots] = new WeaponInventorySlots(_weapon);
        else
            containers[currentWeapon] = new WeaponInventorySlots(_weapon);
    }

    public void AddDefaultWeapon(WeaponObjects _weapon)
    {
        if (CheckEmptySlot() == 0)
        {
            containers[0] = new WeaponInventorySlots(_weapon);
        }
            
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

    private int CheckEmptySlot()
    {
        if (containers[0].weapons == null)
            return 0;
        else if (containers[1].weapons == null)
            return 1;
        else
            return 2;
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
