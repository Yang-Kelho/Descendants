using Realms;

public class PlayerData: RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public string playerId { get; set; }
    
    [MapTo("Password")]
    public string playerPassword { get; set; }

    [MapTo("Score")]
    public int highestScore { get; set; }

    public PlayerData() { }

    public PlayerData(string _playerId, string password, int score)
    {
        playerId = _playerId;
        playerPassword = password;
        highestScore = score;
    }
}
