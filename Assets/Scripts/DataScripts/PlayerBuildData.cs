using UnityEngine;

public class PlayerBuildData
{
    public string runID;
    public string weaponName;
    public string itemName;

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }

    public PlayerBuildData parse(string json)
    {
        return JsonUtility.FromJson<PlayerBuildData>(json);
    }
}
