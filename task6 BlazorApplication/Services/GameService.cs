using Models;

namespace Services;

public class GameService
{
    public Dictionary<string, GameRoom> Rooms { get; set; } = new();
}