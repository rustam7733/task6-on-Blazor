using Models;

namespace Services;

public class GameService
{
    public Dictionary<string, GameRoom> Rooms { get; set; } = [];

    public List<GameRoom> GetWaitingRooms()
    {
        return Rooms.Values
            .Where(r =>
                (r.PlayerX != null && r.PlayerO == null) ||
                (r.PlayerX == null && r.PlayerO != null))
            .ToList();
    }
}