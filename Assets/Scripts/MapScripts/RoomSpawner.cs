using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public RoomTemplates room;
    private MapGenerator mapGen;
    void Start()
    {
        mapGen = FindObjectOfType<MapGenerator>();
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
            else
            {
                float rand = Random.Range(0, 1.0f);
                if (rand > 0.80) // 20% chance of spike room with a single enemy
                {
                    Instantiate(room.spikeRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                }
                else if (!mapGen.spawnedChestRoom && rand < 0.1) // 10% chance of treasure room, one per map max
                {
                    Instantiate(room.chestRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                    mapGen.spawnedChestRoom = true;
                    Debug.Log("spawned chest room");
                }
                else if (!mapGen.spawnedShopRoom && rand < 0.15) // 15% chance of shop room, one per map max
                {
                    Instantiate(room.shopRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                    mapGen.spawnedShopRoom = true;
                    Debug.Log("spawned shop room");
                }
                else // default to room with 2 enemies, 65-80% chance
                {
                    Instantiate(room.roomPrefabs[score - 1], transform.position, Quaternion.identity);
                }

            }
        }
        Destroy(gameObject); // destroys room's spawnpoint
    }
}
