using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private Enemy enemy;
    private float speed;
    private Vector2 moveDir;
    private Vector2 targetPos;
    private Vector2 currentPos;
    private float distance;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        GetCurrentPos();
        targetPos = currentPos;
        speed = enemy.enemy.speed;
    }

    void Update()
    {
        MoveToTarget(targetPos);
    }

    private void FixedUpdate()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = moveDir * speed;
    }

    public void SetTargetPos(Vector2 vector, float distance)
    {
        targetPos = vector;
        this.distance = distance;
    }

    public Vector2 GetTargetPos()
    {
        return targetPos;
    }

    private void GetCurrentPos()
    {
        currentPos = GetComponent<Transform>().position;
    }

    private void StopMove()
    {
        moveDir = Vector2.zero;
    }

    private void MoveToTarget(Vector2 target)
    {
        GetCurrentPos();
        if (targetPos == currentPos || Vector2.Distance(GetComponent<Transform>().position, targetPos) <= distance)
            StopMove();
        else
            moveDir = (targetPos - currentPos).normalized;
    }
}
