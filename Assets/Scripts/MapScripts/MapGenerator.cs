using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridSizeScriptableObject gridSize;
    public GameObject spawnPoint;
    public NeighborRoom room2Spawn;
    public int numOfRooms;
    public int[,] arrayMap;
    public int[,] ScoreMap;
    public int[,] TypeMap;
    private int startRoomPosX;
    private int startRoomPosY;
    public SpawnPointData spd;

    public bool spawnedShopRoom = false;
    public bool spawnedChestRoom = false;

    void Start()
    {
        Vector2 initspawnPointPosition;
        initspawnPointPosition.x = transform.position.x - (((gridSize.mapWidth - 1) / 2) * 1296);
        if (ScoreMap == null && TypeMap == null)
        {
            ArrayMapInit();

            ScoreMap = new int[gridSize.mapHeight, gridSize.mapWidth];
            TypeMap = new int[gridSize.mapHeight, gridSize.mapWidth];
            for (int i = 0; i < (gridSize.mapWidth); i++)
            {
                initspawnPointPosition.y = transform.position.y + (((gridSize.mapHeight - 1) / 2) * 720);
                for (int j = 0; j < (gridSize.mapHeight); j++)
                {
                    spawnPoint.GetComponent<Spawn>().roomScore = arrayMap[j, i];

                    // 0 -> spike room
                    // 1 -> chest room
                    // 2 -> shop
                    // 3 -> regular
                    float rand = Random.Range(0, 1.0f);
                    if (rand > 0.80) // 20% chance of spike room with a single enemy
                    {
                        spawnPoint.GetComponent<Spawn>().roomType = 0;
                    }
                    else if (!spawnedChestRoom && rand < 0.1) // 10% chance of treasure room, one per map max
                    {
                        spawnPoint.GetComponent<Spawn>().roomType = 1;
                        spawnedChestRoom = true;
                    }
                    else if (!spawnedShopRoom && rand < 0.15) // 15% chance of shop room, one per map max
                    {
                        spawnPoint.GetComponent<Spawn>().roomType = 2;
                        spawnedShopRoom = true;
                    }
                    else if (initspawnPointPosition.x == 0 & initspawnPointPosition.y == 0) // set room to regular room if coordinate = (0,0)
                    {
                        spawnPoint.GetComponent<Spawn>().roomType = 3;
                    }
                    else // default to room with 2 enemies, 65-80% chance
                    {
                        spawnPoint.GetComponent<Spawn>().roomType = 3;
                    }


                    ScoreMap[j, i] = spawnPoint.GetComponent<Spawn>().roomScore;
                    TypeMap[j, i] = spawnPoint.GetComponent<Spawn>().roomType;
                    Instantiate(spawnPoint, initspawnPointPosition, Quaternion.identity);
                    initspawnPointPosition.y -= 720;
                }
                initspawnPointPosition.x += 1296;
            }
            GetComponent<SaveLoad>().Save();
        }
        else
        {
            for (int i = 0; i < (gridSize.mapWidth); i++)
            {
                initspawnPointPosition.y = transform.position.y + (((gridSize.mapHeight - 1) / 2) * 720);
                for (int j = 0; j < (gridSize.mapHeight); j++)
                {
                    spawnPoint.GetComponent<Spawn>().roomScore = spd.ScoreMap[j, i];
                    spawnPoint.GetComponent<Spawn>().roomType = spd.TypeMap[j, i];
                    Instantiate(spawnPoint, initspawnPointPosition, Quaternion.identity);
                    initspawnPointPosition.y -= 720;
                }
                initspawnPointPosition.x += 1296;
            }

            spd.ScoreMap = null;
            spd.TypeMap = null;
        }
    }

    private void ArrayMapInit()
    {
        startRoomPosX = (gridSize.mapWidth - 1) / 2;
        startRoomPosY = (gridSize.mapHeight - 1) / 2;
        arrayMap = new int[gridSize.mapHeight, gridSize.mapWidth];
        for (int i = 0; i < (gridSize.mapWidth); i++)
        {
            for (int j = 0; j < (gridSize.mapHeight); j++)
            {
                arrayMap[i, j] = -1;
            }
        }
        ArrayMapGen();
    }

    private void ArrayMapGen()
    {
        List<NeighborRoom> freeRooms = new List<NeighborRoom>();
        Dictionary<int, int> orderRooms = new Dictionary<int, int>();
        arrayMap[startRoomPosY, startRoomPosX] = 0;
        int roomSpawned = 1;
        int randSpawn;
        int randGen;
        freeRooms.Add(new NeighborRoom(startRoomPosY - 1, startRoomPosX));
        freeRooms.Add(new NeighborRoom(startRoomPosY + 1, startRoomPosX));
        freeRooms.Add(new NeighborRoom(startRoomPosY, startRoomPosX + 1));
        freeRooms.Add(new NeighborRoom(startRoomPosY, startRoomPosX - 1));

        while (roomSpawned < numOfRooms)
        {
            randSpawn = Random.Range(0, freeRooms.Count);
            room2Spawn = freeRooms[randSpawn];
            arrayMap[room2Spawn.YPos, room2Spawn.XPos] = 0;
            roomSpawned++;
            freeRooms.RemoveAt(randSpawn);
            CheckNeighbor(room2Spawn);

            for (int i = 1; i <= 4; i++)
            {
                if (!orderRooms.ContainsKey(i))
                    orderRooms.Add(i, i);
            }
            //Add new neighbor room

            while (orderRooms.Count != 0)
            {
                randGen = Random.Range(1, 5);
                if (!orderRooms.ContainsKey(randGen))
                {
                    continue;
                }
                else
                {
                    orderRooms.Remove(randGen);
                }
                switch (randGen)
                {
                    case 1:
                        //check right -1 neighbor
                        if (room2Spawn.XPos + 1 <= gridSize.mapWidth - 1 && arrayMap[room2Spawn.YPos, room2Spawn.XPos + 1] == -1)
                        {
                            NeighborRoom tempRoom = new NeighborRoom(room2Spawn.YPos, room2Spawn.XPos + 1);
                            if(!CompareRooms(freeRooms, tempRoom))
                                freeRooms.Add(tempRoom);
                        }
                        break;
                    case 2:
                        //check left -1 neighbor
                        if (room2Spawn.XPos - 1 >= 0 && arrayMap[room2Spawn.YPos, room2Spawn.XPos - 1] == -1)
                        {
                            NeighborRoom tempRoom = new NeighborRoom(room2Spawn.YPos, room2Spawn.XPos - 1);
                            if (!CompareRooms(freeRooms, tempRoom))
                                freeRooms.Add(tempRoom);
                        }
                        break;
                    case 3:
                        //check top -1 neighbor
                        if (room2Spawn.YPos - 1 >= 0 && arrayMap[room2Spawn.YPos - 1, room2Spawn.XPos] == -1)
                        {
                            NeighborRoom tempRoom = new NeighborRoom(room2Spawn.YPos - 1, room2Spawn.XPos);
                            if (!CompareRooms(freeRooms, tempRoom))
                                freeRooms.Add(tempRoom);
                        }
                        break;
                    case 4:
                        //check bottom -1 neighbor
                        if (room2Spawn.YPos + 1 <= gridSize.mapHeight - 1 && arrayMap[room2Spawn.YPos + 1, room2Spawn.XPos] == -1)
                        {
                            NeighborRoom tempRoom = new NeighborRoom(room2Spawn.YPos + 1, room2Spawn.XPos);
                            if (!CompareRooms(freeRooms, tempRoom))
                                freeRooms.Add(tempRoom);
                        }
                        break;
                }
            }

        }
    }

    public void CheckNeighbor(NeighborRoom room2Spawn)
    {
        int roomConnected = 0;
        int unavailableConnection = 0;
//        int randConnect = Random.Range(1, 4);

        while ((unavailableConnection + roomConnected) != 4)
        {

            //check right
            if (room2Spawn.XPos + 1 <= gridSize.mapWidth - 1 && arrayMap[room2Spawn.YPos, room2Spawn.XPos + 1] > -1)
            {
                ConnectRight(room2Spawn);
                roomConnected++;
            }
            else
                unavailableConnection++;


            //check left
            if (room2Spawn.XPos - 1 >= 0 && arrayMap[room2Spawn.YPos, room2Spawn.XPos - 1] > -1)
            {
                ConnectLeft(room2Spawn);
                roomConnected++;
            }
            else
                unavailableConnection++;

            //check top
            if (room2Spawn.YPos - 1 >= 0 && arrayMap[room2Spawn.YPos - 1, room2Spawn.XPos] > -1)
            {
                ConnectTop(room2Spawn);
                roomConnected++;
            }
            else
                unavailableConnection++;

            //check bottom
            if (room2Spawn.YPos + 1 <= gridSize.mapHeight - 1 && arrayMap[room2Spawn.YPos + 1, room2Spawn.XPos] > -1)
            {
                ConnectBottom(room2Spawn);
                roomConnected++;
            }
            else
                unavailableConnection++;

        }
    }

    // top + 1
    // bottom + 2
    // left + 4
    // right + 8
    private void ConnectRight(NeighborRoom room2Spawn)
    {
        arrayMap[room2Spawn.YPos, room2Spawn.XPos] += 8;
        arrayMap[room2Spawn.YPos, room2Spawn.XPos + 1] += 4;

    }

    private void ConnectLeft(NeighborRoom room2Spawn)
    {
        arrayMap[room2Spawn.YPos, room2Spawn.XPos] += 4;
        arrayMap[room2Spawn.YPos, room2Spawn.XPos - 1] += 8;

    }

    private void ConnectTop(NeighborRoom room2Spawn)
    {
        arrayMap[room2Spawn.YPos, room2Spawn.XPos] += 1;
        arrayMap[room2Spawn.YPos - 1, room2Spawn.XPos] += 2;

    }

    private void ConnectBottom(NeighborRoom room2Spawn)
    {
        arrayMap[room2Spawn.YPos, room2Spawn.XPos] += 2;
        arrayMap[room2Spawn.YPos + 1, room2Spawn.XPos] += 1;
    }

    private bool CompareRooms(List<NeighborRoom> freeRooms, NeighborRoom newRoom)
    {
        for (int i = 0; i < freeRooms.Count; i++)
        {
            if (newRoom.equals(freeRooms[i]))
            {
                return true;
            }
        }
        return false;
    }
}
