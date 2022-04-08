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
    public int startRoomPosX;
    public int startRoomPosY;
    
    void Start()
    {
        Vector2 initspawnPointPosition;
        initspawnPointPosition.x = transform.position.x - (((gridSize.mapWidth - 1) / 2) * 1296);
        ArrayMapInit();
        
        for (int i = 0; i < (gridSize.mapWidth); i++)
        {
            initspawnPointPosition.y = transform.position.y + (((gridSize.mapHeight - 1) / 2) * 720);
            for (int j = 0; j < (gridSize.mapHeight); j++)
            {
                spawnPoint.GetComponent<Spawn>().roomScore = arrayMap[j, i];
                Instantiate(spawnPoint, initspawnPointPosition, Quaternion.identity);
                initspawnPointPosition.y -= 720;
            }
            initspawnPointPosition.x += 1296;
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
        arrayMap[startRoomPosY, startRoomPosX] = 0;
        int roomSpawned = 1;
        int randSpawn;
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

            //Add new neighbor room
            
            //check right -1 neighbor
            if (room2Spawn.XPos + 1 <= gridSize.mapWidth - 1 && arrayMap[room2Spawn.YPos, room2Spawn.XPos + 1] == -1)
            {
                if(!compareRooms(freeRooms,room2Spawn))
                    freeRooms.Add(new NeighborRoom(room2Spawn.YPos, room2Spawn.XPos + 1));
            }

            //check left -1 neighbor
            if (room2Spawn.XPos - 1 >= 0 && arrayMap[room2Spawn.YPos, room2Spawn.XPos - 1] == -1) 
            {
                if(!compareRooms(freeRooms, room2Spawn))
                    freeRooms.Add(new NeighborRoom(room2Spawn.YPos, room2Spawn.XPos - 1));
            }

            //check top -1 neighbor
            if (room2Spawn.YPos - 1 >= 0 && arrayMap[room2Spawn.YPos - 1, room2Spawn.XPos] == -1)
            {
                if (!compareRooms(freeRooms, room2Spawn))
                    freeRooms.Add(new NeighborRoom(room2Spawn.YPos - 1, room2Spawn.XPos));
            }

            //check bottom -1 neighbor
            if (room2Spawn.YPos + 1 <= gridSize.mapHeight - 1 && arrayMap[room2Spawn.YPos + 1, room2Spawn.XPos] == -1)
            {
                if (!compareRooms(freeRooms, room2Spawn))
                    freeRooms.Add(new NeighborRoom(room2Spawn.YPos + 1, room2Spawn.XPos));
            }
        }
    }
    
    public void CheckNeighbor(NeighborRoom room2Spawn)
    {
        int roomConnected = 0;
        int unavailableConnection = 0;
        int randConnect = Random.Range(1, 4);

        while (roomConnected < randConnect && (unavailableConnection + roomConnected) != 4)
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

    private bool compareRooms(List<NeighborRoom> freeRooms, NeighborRoom newRoom)
    {
        for (int i = 0; i < freeRooms.Count; i++)
        {
            if (!newRoom.equals(freeRooms[i]))
            {
                return true;
            }
        }
        return false;
    }
}
