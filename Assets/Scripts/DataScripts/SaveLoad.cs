using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public WeaponInventory inventory;
    public PlayerStats stats;
    public MapGenerator mapGen;
    public RealmController rc;
    public static string path;

    public void Awake()
    {
        mapGen = GetComponent<MapGenerator>();
        path = Application.dataPath + "/Saves/";
    }
    public void Save()
    {
        SaveObject saveFile = new SaveObject();
        saveFile.userName = rc.GetUserName();
        saveFile.maxHealth = stats.maxHealth;
        saveFile.health = stats.health;
        saveFile.gold = stats.gold;
        saveFile.score = stats.score;
        saveFile.speed = stats.speed;
        saveFile.dmgMod = stats.dmgMod;

        var a_scene = SceneManager.GetActiveScene();
        saveFile.level = a_scene.name;

        saveFile.roomScore = new List<int>(new int[mapGen.ScoreMap.GetLength(0) * mapGen.ScoreMap.GetLength(1)]);
        var iter = 0;
        for (int i = 0; i < mapGen.ScoreMap.GetLength(0); i++)
        {
            for (int j = 0; j < mapGen.ScoreMap.GetLength(1); j++)
            {
                saveFile.roomScore.Add(mapGen.ScoreMap[j, i]);
                iter++;
            }
        }

        saveFile.roomType = new List<int>(new int[mapGen.TypeMap.GetLength(0) * mapGen.TypeMap.GetLength(1)]);
        iter = 0;
        for (int i = 0; i < mapGen.TypeMap.GetLength(0); i++)
        {
            for (int j = 0; j < mapGen.TypeMap.GetLength(1); j++)
            {
                saveFile.roomType.Add(mapGen.TypeMap[j, i]);
                iter++;
            }
        }

        string json = JsonUtility.ToJson(saveFile);
        var fileName = "/" + rc.GetUserName() + ".txt";
        Debug.Log(fileName);
        File.WriteAllText(path + fileName, json);
    }

    public void Load()
    {
        
    }
}
