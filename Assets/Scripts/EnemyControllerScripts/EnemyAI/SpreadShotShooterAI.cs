using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotShooterAI : MonoBehaviour
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
    private const float keepOutDistance = 350f;
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
                var positions = TripleShotVectors();
                for (int i = 0; i < 3; i++)
                {
                    GameObject firedProjectile = Instantiate(enemy.enemy.projectile.projectilePrefab, transform.position, Quaternion.identity);
                    firedProjectile.GetComponent<Projectile>().projectile = enemy.enemy.projectile;
                    firedProjectile.GetComponent<Projectile>().damage = enemy.enemy.projectile.damage;
                    firedProjectile.GetComponent<Rigidbody2D>().velocity = positions[i].normalized * enemy.enemy.projectile.projectileSpeed;
                }
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

    private Vector2[] TripleShotVectors()
    {
        Vector2[] positions = new Vector2[3];
        float r = CheckDistance();
        float x = Mathf.Abs(transform.position.x - playerMovement.GetPosition().x);
        float y = Mathf.Abs(transform.position.y - playerMovement.GetPosition().y);
        float initAngle = Mathf.Atan2(y, x) * Mathf.Deg2Rad;
        float secondAngle = (initAngle + 20f) * Mathf.Deg2Rad;
        float thirdAngle = (initAngle - 20f) * Mathf.Deg2Rad;

        float x2 = r * Mathf.Cos(secondAngle);
        float y2 = r * Mathf.Sin(secondAngle);

        //Calculate x3 and y3
        float x3 = r * Mathf.Cos(thirdAngle);
        float y3 = r * Mathf.Sin(thirdAngle);

        //Verify if X is positive or negative
        if (playerMovement.GetPosition().x < transform.position.x)
        {
            x2 = x2 * -1;
            x3 = x3 * -1;
        }

        //Verify if Y is positive or negative
        if (playerMovement.GetPosition().y < transform.position.y)
        {
            y2 = y2 * -1;
            y3 = y3 * -1;
        }

        //Assign Values to positions
        positions[0] = playerMovement.GetPosition();
        positions[1] = new Vector3(transform.position.x + x2, transform.position.y + y2);
        positions[2] = new Vector3(transform.position.x + x3, transform.position.y + y3);
        return positions;
    }
}
    

