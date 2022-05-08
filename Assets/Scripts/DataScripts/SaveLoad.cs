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
    public static string path = Application.dataPath + "/Saves/";

    public void Save()
    {
        SaveObject saveFile = new SaveObject
        {
            userName = rc.GetUserName(),
            maxHealth = stats.maxHealth,
            health = stats.health,
            gold = stats.gold,
            score = stats.score,
            speed = stats.speed,
            dmgMod = stats.dmgMod,
        };

        var a_scene = SceneManager.GetActiveScene();
        saveFile.level = a_scene.name;

        var iter = 0;
        for (int i = 0; i < mapGen.ScoreMap.GetLength(0); i++)
        {
            for (int j = 0; j < mapGen.ScoreMap.GetLength(1); j++)
            {
                saveFile.roomScore[iter] = mapGen.ScoreMap[j, i];
                iter++;
            }
        }

        iter = 0;
        for (int i = 0; i < mapGen.TypeMap.GetLength(0); i++)
        {
            for (int j = 0; j < mapGen.TypeMap.GetLength(1); j++)
            {
                saveFile.roomType[iter] = mapGen.TypeMap[j, i];
                iter++;
            }
        }

        string json = JsonUtility.ToJson(saveFile);
        File.WriteAllText(path + "/" + rc.GetUserName(), json);
    }

    public void Load()
    {
        
    }
}
