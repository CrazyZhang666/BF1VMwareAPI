namespace BF1VMwareAPI.Models;

public class GameState
{
    public bool IsMultiplayer { get; set; }
    public bool IsCoop { get; set; }
    public bool IsMenu { get; set; }
    public bool IsEpilogue { get; set; }

    public int ClientStateId { get; set; }
    public string ClientState { get; set; }
    public int GameTypeId { get; set; }
    public string GameType { get; set; }
}