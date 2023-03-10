namespace Crosses.Core;

public record MoveResult(bool MoveSucceeded, Game Game)
{
    public static MoveResult Success(Game game) => new MoveResult(true, game);
    public static MoveResult NotBlank(Game game) => new MoveResult(false, game);

    public T Match<T>(Func<Game, T> success, Func<Game, T> notBlank)
    {
        return MoveSucceeded ? success(Game) : notBlank(Game);
    }
}