namespace Crosses.Core;

public record Game(Board Board, GameState State)
{
    public static Game Start()
    {
        return new Game(new Board(), GameState.InProgress(Player.O));
    }

    public Result<Game, InvalidMove> MoveAt(int x, int y)
    {
        return State.Match(state =>
            {
                if (Board.GetSquareState(x, y) == SquareState.Blank)
                {
                    var newBoard = Board.SetSquareState(x, y, state.NextTurn);
                    var newState = newBoard.IsFull()
                        ? GameState.Complete
                        : GameState.InProgress(Player.Other(state.NextTurn));
                    return Result<Game, InvalidMove>.Success(
                        new Game(newBoard,
                            newState)
                    );
                }

                return Result<Game, InvalidMove>.Failure(new InvalidMove(state.NextTurn, x, y));
            },
            _ => Result<Game, InvalidMove>
                .Success(this) //This doesn't really make sense.  Move should only be possible when InProgress
        );
    }

    public record InvalidMove(Player Player, int X, int Y);
}