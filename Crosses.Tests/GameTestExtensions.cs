using System;
using Crosses.Core;

namespace Crosses.Tests;

static class GameTestExtensions
{
    public static Game Print(this Game game)
    {
        Console.WriteLine(game.Board);
        Console.WriteLine(game.State.Match(
            inProgress => $"Next player: {inProgress.NextTurn}",
            _ => "Game over"
        ));
        return game;
    }
}