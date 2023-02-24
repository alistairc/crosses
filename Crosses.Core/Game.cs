namespace Crosses.Core;

public record Game(Board Board, Player NextTurn)
{
    public static Game Start()
    {
        return new Game(new Board(), Player.O);
    }

    public Game MoveAt(int x, int y)
    {
        return this with
        {
            Board = Board.SetState(x, y, NextTurn),
            NextTurn = OtherPlayer(NextTurn)
        };
    }

    static Player OtherPlayer(Player currentPlayer)
    {
        return currentPlayer switch
        {
            Player.O => Player.X,
            Player.X => Player.O,
            _ => throw new ArgumentOutOfRangeException(nameof(currentPlayer), currentPlayer, null)
        };
    }
}