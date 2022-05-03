using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool cleared = false;
    Door[] doors;
    SoundManager sm;


    private void Start()
    {
        doors = this.GetComponentInChildren<Grid>().GetComponentsInChildren<Door>();
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!cleared && collision.CompareTag("Player"))
        {
            foreach (SpawnEnemy c in this.GetComponentsInChildren<SpawnEnemy>())
            {
                c.spawn();
                Destroy(c.gameObject);
            }
        }
    }

    public void checkClear()
    {
        if (AllEnemiesDefeated())
        {
            foreach (Door d in doors)
            {
                d.gameObject.SetActive(false);
            }
            sm.PlaySound("doorOpen");
        }
    }
    private bool AllEnemiesDefeated()
    {
        foreach (var enemy in GetComponentsInChildren<Enemy>())
        {

            if (enemy.isActiveAndEnabled)
            {
                return false;
            }
        }
        return true;
    } 

    public void closeDoor()
    {
        Grid g = GetComponentInChildren<Grid>();
        foreach (Door d in g.GetComponentsInChildren<Door>())
        {
            d.GetComponent<Renderer>().enabled = true;
        }
        sm.PlaySound("doorClose");
    }
}
