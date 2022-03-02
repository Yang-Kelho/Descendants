using UnityEngine;

public class PlayerBuildData
{
    public string runID;
    public string weaponName;
    public string itemName;

    public string ConvertToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public PlayerBuildData Parse(string json)
    {
        return JsonUtility.FromJson<PlayerBuildData>(json);
    }
}
