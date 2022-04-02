using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicShooter", menuName = "Enemies/BasicShooter")]
public class BasicShooter : EnemyObjects
{

    public void Awake()
    {
        eliteCheck = EliteRoll();
    }

    public BasicShooter()
    {
        maxHp = 20f;
        speed = 250f;
    }
}
