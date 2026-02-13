namespace Models;

public class TicTacToe
{
    public string[] GameBoard { get; set; } = new string[9];
    public string CurrentPlayer { get; set; } = "X";
    public bool GameOver { get; set; } = false;
    public string Winner { get; set; } = "";
    public int[] WinningPattern { get; set; } = [];

    private readonly int[][] winPatterns =
    [
        [0,1,2], [3,4,5], [6,7,8],
        [0,3,6], [1,4,7], [2,5,8],
        [0,4,8], [2,4,6]
    ];

    private readonly object _lock = new();

    public void Move(int index, string player)
    {
        lock (_lock)
        {
            if (player == "spectator") return;
            if (GameOver) return;
            if (CurrentPlayer != player) return;
            if (!string.IsNullOrEmpty(GameBoard[index])) return;

            GameBoard[index] = player;

            CheckWinner();

            if (!GameOver)
                CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        }
    }

    private void CheckWinner()
    {
        foreach (var combo in winPatterns)
        {
            if (!string.IsNullOrEmpty(GameBoard[combo[0]]) &&
                GameBoard[combo[0]] == GameBoard[combo[1]] &&
                GameBoard[combo[1]] == GameBoard[combo[2]])
            {
                Winner = GameBoard[combo[0]];
                WinningPattern = combo;
                GameOver = true;
                return;
            }
        }

        if (GameBoard.All(x => !string.IsNullOrEmpty(x)))
        {
            Winner = "Draw";
            GameOver = true;
        }
    }

    public void Restart()
    {
        GameBoard = new string[9];
        CurrentPlayer = "X";
        GameOver = false;
        Winner = "";
        WinningPattern = [];
    }
}