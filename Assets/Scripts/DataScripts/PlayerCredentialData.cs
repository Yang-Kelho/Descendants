using UnityEngine;

public class PlayerCredentialData
{
    public string playerName;
    public string passwordSalt;
    public string passwordHash;

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }

    public PlayerCredentialData parse(string json)
    {
        return JsonUtility.FromJson<PlayerCredentialData>(json);
    }
}
