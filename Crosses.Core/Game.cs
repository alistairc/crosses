namespace Crosses.Core;

public record Game(Board Board, Player NextTurn)
{
    public static Game Start()
    {
        return new Game(new Board(), Player.O);
    }

    public MoveResult MoveAt(int x, int y)
    {
        if (Board.GetSquareState(x, y) == SquareState.Blank)
            return MoveResult.Success(this with
            {
                Board = Board.SetSquareState(x, y, NextTurn),
                NextTurn = Player.Other(NextTurn)
            });

        return MoveResult.NotBlank(this);
    }
}