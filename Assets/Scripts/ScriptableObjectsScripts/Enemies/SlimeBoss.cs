using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlimeBoss", menuName = "Enemies/SlimeBoss")]
public class SlimeBoss : EnemyObjects
{ 
    public SlimeBoss()
    {
        maxHp = 100f;
        speed = 0f;
        atkCoolDown = 10f;
        goldDropped = 80;
        score = 1000;
    }
}
