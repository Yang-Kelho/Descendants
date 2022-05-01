using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPF;
    public void spawn()
    {
        GameObject enemy = Instantiate(enemyPF, this.transform.position, Quaternion.identity);
        enemy.transform.SetParent(transform.parent);
    }
}
