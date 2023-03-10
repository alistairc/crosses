namespace Crosses.Core;

public record Game(Board Board, Player NextTurn)
{
    public record InvalidMove(Player Player, int X, int Y);
    
    public static Game Start()
    {
        return new Game(new Board(), Player.O);
    }

    public Result<Game, InvalidMove> MoveAt(int x, int y)
    {
        if (Board.GetSquareState(x, y) == SquareState.Blank)
            return Result<Game, InvalidMove>.Success(
                new Game(Board: Board.SetSquareState(x, y, NextTurn), NextTurn: Player.Other(NextTurn))
            );

        return Result<Game, InvalidMove>.Failure(new InvalidMove(NextTurn, x, y));
    }
}