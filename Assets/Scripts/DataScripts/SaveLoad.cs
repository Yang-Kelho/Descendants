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
    private bool map;

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
        string saveString;
        var name = "/" + rc.GetUserName() + ".txt";
        if (File.Exists(path + name))
        {
            saveString = File.ReadAllText(path + name);
        }
        else
            saveString = "none";

        SaveObject saveFile = new SaveObject();

        if (saveString != "none")
        {
            saveFile = JsonUtility.FromJson<SaveObject>(saveString);
        }
        else
            Debug.Log("no existing save");

        if (saveFile != null)
        {
            var scene = SceneManager.GetSceneByName(saveFile.level);

            GameObject[] objects = scene.GetRootGameObjects();

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].name == "MapGen")
                {
                    mapGen = objects[i].GetComponent<MapGenerator>();
                    map = true;
                }
                else
                    map = false;
            }

            if (map != false)
            {
                var iter = 0;
                for (int i = 0; i < saveFile.roomScore.Count; i++)
                {
                    for (int j = 0; j < saveFile.roomScore.Count; j++)
                    {
                        mapGen.ScoreMap[j, i] = saveFile.roomScore[iter];
                        mapGen.TypeMap[j, i] = saveFile.roomType[iter];
                    }
                }
            }

            stats.maxHealth = saveFile.maxHealth;
            stats.health = saveFile.health;
            stats.gold = saveFile.gold;
            stats.score = saveFile.score;
            stats.speed = saveFile.speed;
            stats.dmgMod = saveFile.dmgMod;

            SceneManager.LoadScene(saveFile.level);
        }
    }
}
