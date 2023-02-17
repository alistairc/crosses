using System;

namespace Crosses.Tests;

record Board
{
    private SquareState[,] State { get; init; } = new SquareState[3, 3];

    public SquareState StateAt(int x, int y)
    {
        return State[x, y];
    }

    public Board MoveAt(int x, int y, Player player)
    {
        var newState = (SquareState[,])State.Clone();
        newState[x, y] = StateFromPlayer(player);
        return new Board { State = newState };
    }

    private static SquareState StateFromPlayer(Player player)
    {
        return player switch
        {
            Player.O => SquareState.Nought,
            Player.X => SquareState.Cross,
            _ => throw new ArgumentOutOfRangeException(nameof(player), player, null)
        };
    }
}