using UnityEngine;

public class PlayerRunData
{
    public string runID;
    public string playerName;
    public int score;

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }

    public PlayerRunData parse(string json)
    {
        return JsonUtility.FromJson<PlayerRunData>(json);
    }
}
