using System.Collections.Immutable;

namespace Crosses.Core;

public record Board
{
    public static readonly Board Blank = new();

    ImmutableArray<SquareState> NewState { get; init; } = ImmutableArray.CreateRange(Enumerable.Repeat(SquareState.Blank, 9));

    public SquareState StateAt(int x, int y)
    {
        return NewState[IndexForCoord(x, y)];
    }

    public Board MoveAt(int x, int y, Player player)
    {
        var index = IndexForCoord(x, y);
        var mutable = NewState.ToBuilder();
        mutable[index] = StateFromPlayer(player);
        return new Board { NewState = mutable.ToImmutable() };
    }

    static int IndexForCoord(int x, int y)
    {
        return x + y * 3;
    }
    
    static SquareState StateFromPlayer(Player player)
    {
        return player switch
        {
            Player.O => SquareState.Nought,
            Player.X => SquareState.Cross,
            _ => throw new ArgumentOutOfRangeException(nameof(player), player, null)
        };
    }
}