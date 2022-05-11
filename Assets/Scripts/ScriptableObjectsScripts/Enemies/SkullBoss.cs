using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkullBoss", menuName = "Enemies/SkullBoss")]
public class SkullBoss : EnemyObjects
{
    public SkullBoss()
    {
        maxHp = 200f;
        speed = 250f;
        atkCoolDown = 4f;
        goldDropped = 400;
        score = 5000;
    }
}
