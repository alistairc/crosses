using System;
using Crosses.Core;

namespace Crosses.Tests;

static class GameTestExtensions
{
    public static Game Print(this Game game)
    {
        Console.WriteLine(game.Board);
        Console.WriteLine($"Next player: {game.NextTurn}");
        return game;
    }
}