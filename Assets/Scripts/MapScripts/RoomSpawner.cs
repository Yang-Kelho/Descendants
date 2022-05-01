using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public RoomTemplates room;
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        int score = GetComponent<Spawn>().roomScore;
        if (score == -1)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject r = Instantiate(room.roomPrefabs[score - 1], transform.position, Quaternion.identity);
            if (r.transform.position == Vector3.zero)
            {
                foreach (SpawnEnemy sp in r.GetComponentsInChildren<SpawnEnemy>()) {
                    Destroy(sp.gameObject);
                }
                foreach (Door d in r.GetComponentsInChildren<Door>())
                {
                    Destroy(d.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}
