using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int _numBullets;
    public float bulletSpeed;
    private GameObject BulletPrefab;
    float atkCooldown = 0;
    [Header("Private Variables")]
    private Vector2 startPoint;
    private Enemy enemy;
    private const float radius = 1f;

    private void Awake()
    {
        //set projectile prefab
        BulletPrefab = GetComponent<Enemy>().enemy.projectile.projectilePrefab;
        enemy = GetComponent<Enemy>();
    }

    void FixedUpdate()
    {
        if (atkCooldown > 0)
        {
            atkCooldown -= Time.deltaTime;
        }
        else
        {
            // chance to do one of three attacks
            int rand = Random.Range(0, 3);
            Debug.Log(rand);
            switch (rand)
            {
                case 2: // spawn double spiral
                    StartCoroutine(SpiralShoot(30, true, 0.1f));
                    break;
                case 1: // spawn single spiral
                    StartCoroutine(SpiralShoot(30, false, 0.1f));
                    break;
                default: // spawn 5 rings
                    StartCoroutine(RingShoot(10, 15, 0.5f));
                    break;
        }
            // reset cooldown
            atkCooldown = 4;
        }
    }

    private void SpawnBulletRing(int numBullets, Vector2 startPoint)
    {
        float angleStep = 360f / numBullets;
        float angle = 0f;

        for (int i = 0; i < numBullets; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDir = (projectileVector - startPoint).normalized * bulletSpeed;

            GameObject tmpObj = Instantiate(BulletPrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Projectile>().projectile = enemy.enemy.projectile;
            tmpObj.GetComponent<Projectile>().damage = enemy.enemy.projectile.damage;
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);
            angle += angleStep;
        }
    }
    private IEnumerator RingShoot(int minBullets, int maxBullets, float waitTime)
    {
        for (int i = minBullets; i < maxBullets; i++)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnBulletRing(i, transform.position);
        }
    }

    private void SpawnBulletSpiral(Vector2 startPoint, bool isDoubleSpiral, float angle)
    {
        float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
        float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

        Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
        Vector2 projectileMoveDir = (projectileVector - startPoint).normalized * (1.5f * bulletSpeed);

        GameObject tmpObj = Instantiate(BulletPrefab, startPoint, Quaternion.identity);
        tmpObj.GetComponent<Projectile>().projectile = enemy.enemy.projectile;
        tmpObj.GetComponent<Projectile>().damage = enemy.enemy.projectile.damage;
        tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);
        if (isDoubleSpiral)
        {
            // spawn bullet going in opposite direction
            GameObject tmpObj2 = Instantiate(BulletPrefab, startPoint, Quaternion.identity);
            tmpObj2.GetComponent<Projectile>().projectile = enemy.enemy.projectile;
            tmpObj2.GetComponent<Projectile>().damage = enemy.enemy.projectile.damage;
            tmpObj2.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileMoveDir.x, -projectileMoveDir.y);
        }
    }

    private IEnumerator SpiralShoot(int numBullets, bool isDoubleSpiral, float waitTime)
    {
        float angle = 0f;
        float angleStep = 360f / numBullets;
        for (int i = 0; i < numBullets; i++)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnBulletSpiral(transform.position, isDoubleSpiral, angle);
            angle += angleStep;
        }
    }
}
