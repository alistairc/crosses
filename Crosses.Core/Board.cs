using System.Collections.Immutable;

namespace Crosses.Core;

public record Board
{
    public static readonly Board Blank = new();

    ImmutableArray<Option<Player>> State { get; init; } =
        ImmutableArray.CreateRange(Enumerable.Repeat(Option<Player>.None, 9));

    public virtual bool Equals(Board? other)
    {
        //Really annoying to have to do this, but Immutable array doesn't implement value equality
        //We'll need remember to update this if we add other members
        return other != null && Enumerable.SequenceEqual(other.State, State);
    }

    public Option<Player> GetSquareState(int x, int y)
    {
        return State[IndexForCoord(x, y)];
    }

    public Board SetSquareState(int x, int y, Player player)
    {
        var index = IndexForCoord(x, y);
        var mutable = State.ToBuilder();
        mutable[index] = Option<Player>.Some(player);
        return new Board { State = mutable.ToImmutable() };
    }

    public bool IsFull()
    {
        return !State.Any(square => square == Option<Player>.None);
    }

    static int IndexForCoord(int x, int y)
    {
        return x + y * 3;
    }

    public override string ToString()
    {
        return $"{State[0]}{State[1]}{State[2]}\n" +
               $"{State[3]}{State[4]}{State[5]}\n" +
               $"{State[6]}{State[7]}{State[8]}";
    }

    public override int GetHashCode()
    {
        return State.Aggregate(
            typeof(Board).GetHashCode(),
            (i, state) => i ^ state.GetHashCode()
        );
    }
}