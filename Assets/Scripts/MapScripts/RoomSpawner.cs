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
        if (score != -1)
        {
            if (transform.position == Vector3.zero) // location of spawn room
            {
                //GameObject r = Instantiate(room.emptyRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                GameObject r = Instantiate(room.roomPrefabs[score - 1], transform.position, Quaternion.identity);
                // prevent enemies from spawning in spawn room
                foreach (SpawnEnemy sp in r.GetComponentsInChildren<SpawnEnemy>())
                {
                    DestroyImmediate(sp.gameObject);
                }
                foreach (Door d in r.GetComponentsInChildren<Door>())
                {
                    Destroy(d.gameObject);
                }
            }
            // 0 -> spike room
            // 1 -> chest room
            // 2 -> shop
            // 3 -> regular
            else
            {
                if (GetComponent<Spawn>().roomType == 0)
                {
                    Instantiate(room.spikeRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                }
                else if (GetComponent<Spawn>().roomType == 1)
                {
                    Instantiate(room.chestRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                    GetComponent<Spawn>().roomType = 1;
                    Debug.Log("spawned chest room");
                }
                else if (GetComponent<Spawn>().roomType == 2)
                {
                    Instantiate(room.shopRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                    GetComponent<Spawn>().roomType = 2;
                    Debug.Log("spawned shop room");
                }
                else if(GetComponent<Spawn>().roomType == 3)
                {
                    Instantiate(room.roomPrefabs[score - 1], transform.position, Quaternion.identity);
                }

            }
        }
        Destroy(gameObject); // destroys room's spawnpoint
    }
}
