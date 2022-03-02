using UnityEngine;

public class PlayerRunData
{
    public string runID;
    public string playerName;
    public int score;

    public string ConvertToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public PlayerRunData Parse(string json)
    {
        return JsonUtility.FromJson<PlayerRunData>(json);
    }
}
