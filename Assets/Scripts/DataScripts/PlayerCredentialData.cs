using UnityEngine;

public class PlayerCredentialData
{
    public string playerName;
    public string passwordSalt;
    public string passwordHash;

    public string ConvertToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public PlayerCredentialData Parse(string json)
    {
        return JsonUtility.FromJson<PlayerCredentialData>(json);
    }
}
