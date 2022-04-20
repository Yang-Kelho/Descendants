using Realms;

public class PlayerData: RealmObject
{
    [PrimaryKey]
    [MapTo("PlayerId")]
    public string playerId { get; set; }
    
    [MapTo("Password")]
    public string playerPassword { get; set; }

    [MapTo("Score")]
    public int highestScore { get; set; }

    public PlayerData() { }

    public PlayerData(string id, string password, int score)
    {
        playerId = id;
        playerPassword = password;
        highestScore = score;
    }
}
