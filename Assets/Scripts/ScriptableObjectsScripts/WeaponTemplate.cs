using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTemplate", menuName = "WeaponTemplate")]
public class WeaponTemplate : ScriptableObject
{
    public List<WeaponObjects> weapon;
}
