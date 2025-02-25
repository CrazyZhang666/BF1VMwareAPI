namespace BF1VMwareAPI.Models;

public class ServerData
{
    public string Name { get; set; }
    public long GameId { get; set; }

    public string MapName { get; set; }
    public string MapName2 { get; set; }
    public string GameMode { get; set; }
    public string GameMode2 { get; set; }

    public float GameTime { get; set; }
}