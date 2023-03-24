using System;

namespace Crosses.Tests;

static class GameTestExtensions
{
    public static Game Print(this Game game)
    {
        Console.WriteLine(game.Board);
        Console.WriteLine(game.State.Match(
            inProgress => $"Next player: {inProgress.NextTurn}",
            onComplete: _ => "Game over",
            won => $"Winner: {won.Winner}"
        ));
        return game;
    }
}