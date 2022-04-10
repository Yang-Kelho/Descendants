using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooterAI : MonoBehaviour
{
    public EnemyPathing pathFinder;
    public PlayerMovementController playerMovement;
    private Vector2 lastDir;

    private enum State
    {
        Chase,
        Attack,
    }
    void Start()
    {
        pathFinder = GetComponent<EnemyPathing>();
    }

    void Update()
    {
        float keepOutDistance = 100f;
        if (Vector2.Distance(GetComponent<Transform>().position, playerMovement.transform.position) > keepOutDistance)
        {
            pathFinder.SetTargetPos(playerMovement.GetPosition(), keepOutDistance);
        }

        //code below is to make that if the player is too close it will back off. Does not work well
        //        else if (Vector2.Distance(GetComponent<Transform>().position, playerMovement.transform.position) < keepOutDistance)
        //        {
        //            Vector2 pos = playerMovement.GetPosition();
        //            if (pos == Vector2.zero)
        //            {
        //                pos = lastDir;
        //                pathFinder.SetTargetPos(pos);
        //                lastDir = pos;
        //            }
        //            pos.x *= -1;
        //            pos.y *= -1;
        //            lastDir = pos;
        //        }
        //    }
    }
}
