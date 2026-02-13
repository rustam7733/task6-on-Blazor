namespace Models;

public class GameRoom
{
    public string Id { get; set; } = string.Empty;

    public TicTacToe Game { get; set; } = new();

    public string? PlayerX { get; set; }
    public string? PlayerO { get; set; }
}
