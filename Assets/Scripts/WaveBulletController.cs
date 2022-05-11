using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    private GameObject BulletPrefab;
    [Header("Private Variables")]
    float atkCooldown = 0;
    private float bulletSpeed;
    private Enemy enemy;
    private bool movingRight = true;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        //set projectile prefab
        BulletPrefab = enemy.enemy.projectile.projectilePrefab;
        bulletSpeed = enemy.enemy.projectile.projectileSpeed;
        atkCooldown = enemy.enemy.atkCoolDown;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x) >= 550)
        {
            movingRight = !movingRight;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime * enemy.enemy.speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime * enemy.enemy.speed, transform.position.y);
        }

        if (atkCooldown > 0)
        {
            atkCooldown -= Time.deltaTime;
        }
        else
        {
            // chance to do one of three attacks
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 2: // spawn a nova
                    StartCoroutine(NovaShoot(10, 15, 0.1f));
                    break;
                case 1: // spawn a zigzag
                    StartCoroutine(ZigZagShoot(30, 0.1f));
                    break;
                default: // spawn a wave 
                    StartCoroutine(WaveShoot(15, 1f));
                    break;
            }
            // reset cooldown
            atkCooldown = GetComponent<Enemy>().enemy.atkCoolDown;
        }
    }
    private void SpawnBullet(float angle, Vector2 startPoint)
    {
        float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180);
        float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180);

        Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
        Vector2 projectileMoveDir = (projectileVector - startPoint).normalized * bulletSpeed;

        GameObject tmpObj = Instantiate(BulletPrefab, startPoint, Quaternion.identity);
        tmpObj.GetComponent<Projectile>().projectile = enemy.enemy.projectile;
        tmpObj.GetComponent<Projectile>().damage = enemy.enemy.projectile.damage;
        tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);

        float rotationAngle = Mathf.Atan2(projectileMoveDir.y, projectileMoveDir.x) * Mathf.Rad2Deg;
        tmpObj.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    private IEnumerator WaveShoot(int numBullets, float waitTime)
    {
        for (int i = 0; i < numBullets; i++)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnWave(numBullets, transform.position);
        }
    }

    private void SpawnWave(int numBullets, Vector2 startPoint)
    {
        float angleStep = 120f / numBullets;
        for (int i = 0; i < numBullets; i++)
        {
            SpawnBullet(120f + i * angleStep, startPoint);
        }
    }

    private IEnumerator ZigZagShoot(int numBullets, float waitTime)
    {
        float angleStep = 360f / numBullets;
        float[] angles = new float[numBullets * 2 - 1];
        for (int i = 0; i < numBullets; i++)
        {
            angles[i] = i * angleStep - 90f;
            angles[numBullets - 1 - i] = i * angleStep - 90f;
        }
        for (int i = 0; i < numBullets; i++)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnBullet(angles[i], transform.position);
        }
    }

    private IEnumerator NovaShoot(int minBullets, int maxBullets, float waitTime)
    {
        for (int i = minBullets; i < maxBullets; i++)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnNova(i, transform.position);
        }
    }
    private void SpawnNova(int numBullets, Vector2 startPoint)
    {
        float angleStep = 360f / numBullets;
        float angle = 0f;

        for (int i = 0; i < numBullets; i++)
        {
            SpawnBullet(angle, startPoint);
            angle += angleStep;
        }
    }
}
