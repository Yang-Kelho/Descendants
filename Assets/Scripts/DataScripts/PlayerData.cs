using Realms;

public class PlayerData : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public string playerId { get; set; }

    [MapTo("Pid")]
    public string pId { get; set; }

    [MapTo("Password")]
    public string playerPassword { get; set; }

    [MapTo("Score")]
    public long highestScore { get; set; }

    public PlayerData() { }

    public PlayerData(string _playerId, string password, int score)
    {
        playerId = _playerId;
        pId = "partition";
        playerPassword = password;
        highestScore = score;
    }
}
