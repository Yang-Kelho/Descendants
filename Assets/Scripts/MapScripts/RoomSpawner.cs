using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSpawner : MonoBehaviour
{
    public RoomTemplates room;
    GameObject[] spikeRoomPrefabs;
    GameObject[] chestRoomPrefabs;
    GameObject[] shopRoomPrefabs;
    GameObject[] roomPrefabs;
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        switch (SceneManager.GetActiveScene().name)
        {
            case "Floor3":
                roomPrefabs = room.roomPrefabs3;
                spikeRoomPrefabs = room.spikeRoomPrefabs3;
                chestRoomPrefabs = room.chestRoomPrefabs3;
                shopRoomPrefabs = room.shopRoomPrefabs3;
                break;
            case "Floor2":
                roomPrefabs = room.roomPrefabs2;
                spikeRoomPrefabs = room.spikeRoomPrefabs2;
                chestRoomPrefabs = room.chestRoomPrefabs2;
                shopRoomPrefabs = room.shopRoomPrefabs2;
                break;
            default: 
                roomPrefabs = room.roomPrefabs;
                spikeRoomPrefabs = room.spikeRoomPrefabs;
                chestRoomPrefabs = room.chestRoomPrefabs;
                shopRoomPrefabs = room.shopRoomPrefabs;
                break;
        }
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
                GameObject r = Instantiate(roomPrefabs[score - 1], transform.position, Quaternion.identity);
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
                    Instantiate(spikeRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                }
                else if (GetComponent<Spawn>().roomType == 1)
                {
                    Instantiate(chestRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                    GetComponent<Spawn>().roomType = 1;
                    Debug.Log("spawned chest room");
                }
                else if (GetComponent<Spawn>().roomType == 2)
                {
                    Instantiate(shopRoomPrefabs[score - 1], transform.position, Quaternion.identity);
                    GetComponent<Spawn>().roomType = 2;
                    Debug.Log("spawned shop room");
                }
                else if(GetComponent<Spawn>().roomType == 3)
                {
                    Instantiate(roomPrefabs[score - 1], transform.position, Quaternion.identity);
                }

            }
        }
        Destroy(gameObject); // destroys room's spawnpoint
    }
}
