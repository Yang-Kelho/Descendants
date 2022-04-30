using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpreadShotShooter", menuName = "Enemies/SpreadShotShooter")]
public class SpreadShotShooter : EnemyObjects
{
    public void Awake()
    {
        eliteCheck = EliteRoll();
    }

    public SpreadShotShooter()
    {
        maxHp = 20f;
        speed = 250f;
        atkCoolDown = 10f;
        goldDropped = 25;
        score = 200;
    }
}
