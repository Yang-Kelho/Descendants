using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooterAI : MonoBehaviour
{
    private enum State
    {
        Chase,
        Attack,
    }
    public EnemyPathing pathFinder;
    public PlayerMovementController playerMovement;
    public Enemy enemy;
    private float atkCoolDown = 0;
    private Vector2 lastMvDir;
    private Vector2 atkDir;
    private const float keepOutDistance = 100f;
    private State state;
    private Vector2 selfPosition;

    void Start()
    {
        pathFinder = GetComponent<EnemyPathing>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
       selfPosition = GetComponent<Transform>().position;      
       float distance = CheckDistance();
       if (distance > keepOutDistance)
       {
           state = State.Chase;
       }
       else if (distance <= keepOutDistance)
       {
            state = State.Attack;
       }

        switch (state)
        {
            case State.Chase:
                ChaseTarget(keepOutDistance);
                atkDir = Vector2.zero;
                break;
            case State.Attack:
                AttackPlayer();
                break;
        }
    }

    private void FixedUpdate()
    {
        if (atkCoolDown > 0)
        {
            atkCoolDown -= Time.deltaTime;
        }  
        if (atkDir != Vector2.zero)
        {
            if (atkCoolDown <= 0)
            {
                GameObject firedProjectile = Instantiate(enemy.enemy.projectile.projectilePrefab, transform.position, Quaternion.identity);
                firedProjectile.GetComponent<Projectile>().projectile = enemy.enemy.projectile;
                firedProjectile.GetComponent<Projectile>().damage = enemy.enemy.projectile.damage;
                firedProjectile.GetComponent<Rigidbody2D>().velocity = atkDir.normalized * enemy.enemy.projectile.projectileSpeed;
                atkCoolDown = enemy.enemy.atkCoolDown;
            }        
        }
    }

    private float CheckDistance()
    {
        return Vector2.Distance(GetComponent<Transform>().position, playerMovement.GetPosition());
    }

    private void AttackPlayer()
    {
        atkDir = playerMovement.GetPosition() - selfPosition;
    }

    private void ChaseTarget(float keepOutDistance)
    {
        pathFinder.SetTargetPos(playerMovement.GetPosition(), keepOutDistance);
//        else if (Vector2.Distance(GetComponent<Transform>().position, playerMovement.transform.position) < keepOutDistance)
//        {
//            Vector2 pos = playerMovement.GetPosition();
//            state = State.Attack;
//            if (pos == Vector2.zero)
//            {
//                pos = lastMvDir;
//               pathFinder.SetTargetPos(pos, keepOutDistance);
//                lastMvDir = pos;
//            }
//            else
//            {
//                pos.x *= -1;
//                pos.y *= -1;
//                pathFinder.SetTargetPos(pos, keepOutDistance);
//                lastMvDir = pos;
    }
}
    

