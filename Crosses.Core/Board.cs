using System.Collections.Immutable;

namespace Crosses.Core;

public record Board
{
    public static readonly Board Blank = new();

    ImmutableArray<SquareState> NewState { get; init; } = ImmutableArray.CreateRange(Enumerable.Repeat(SquareState.Blank, 9));

    public SquareState GetSquareState(int x, int y)
    {
        return NewState[IndexForCoord(x, y)];
    }

    public Board SetSquareState(int x, int y, Player player)
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
    
    public virtual bool Equals(Board? other)
    {
        //Really annoying to have to do this, but Immutable array doesn't implement value equality
        //We'll need remember to update this if we add other members
        return other != null && Enumerable.SequenceEqual(other.NewState, NewState);
    }

    public override int GetHashCode()
    {
        return NewState.Aggregate(
            typeof(Board).GetHashCode(),
            (i, state) => i ^ state.GetHashCode()
        );
    }
}