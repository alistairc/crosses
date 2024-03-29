namespace Crosses.Core;

public record Game(Board Board, GameState State)
{
    public static Game Start()
    {
        return new Game(new Board(), GameState.InProgress(Player.O));
    }

    public Result<Game, InvalidMove> MoveAt(int x, int y)
    {
        return State.Match(inProgress =>
            {
                if (Board.GetSquareState(x, y) != Option<Player>.None)
                {
                    return Result<Game, InvalidMove>.Failure(new InvalidMove(inProgress.NextTurn, x, y));
                }

                var newBoard = Board.SetSquareState(x, y, inProgress.NextTurn);
                var newState = NextState(newBoard, inProgress.NextTurn);
                return Result<Game, InvalidMove>.Success(new Game(newBoard, newState));
            },
            _ => Result<Game, InvalidMove>
                .Success(this), //This doesn't really make sense.  Move should only be possible when InProgress
            _ => Result<Game, InvalidMove>
                .Success(this) //This doesn't really make sense.  Move should only be possible when InProgress
        );
    }

    static GameState NextState(Board newBoard, Player currentTurn)
    {
        if (newBoard.IsFull()) return GameState.Complete; // potential bug here, you can win on a full board

        return HasWinner(newBoard).Match(
            onSuccess: GameState.Won,
            onFailure: _ => GameState.InProgress(Player.Other(currentTurn))
        );
    }

    static Result<Player, NoWinner> HasWinner(Board board)
    {
        //there are more ways to win than this!
        var squaresOnRowOne = Enumerable.Range(0, 2).Select(x => board.GetSquareState(x, 0));

        var distinctValues = squaresOnRowOne.Distinct().ToArray();
        if (distinctValues.Length == 1)
        {
            return distinctValues[0].Match(
                player => Result<Player, NoWinner>.Success(player),
                onNone: () => Result<Player, NoWinner>.Failure(NoWinner.Value)
            );
        }

        return Result<Player, NoWinner>.Failure(NoWinner.Value);
    }

    record NoWinner
    {
        public static readonly NoWinner Value = new();
    }

    public record InvalidMove(Player Player, int X, int Y);
}