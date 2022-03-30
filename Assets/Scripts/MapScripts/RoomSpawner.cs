using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public RoomTemplates room;
    void Start()
    {
        Invoke(nameof(Spawn), 1f);
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
            Instantiate(room.roomPrefabs[score - 1], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
