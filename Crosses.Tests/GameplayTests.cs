using Crosses.Core;

namespace Crosses.Tests;

public class GameplayTests
{
    [Test]
    public void PlayingACompleteGame()
    {
        var result = Game.Start().Print()
                .MoveAt(0, 0).Game.Print()
                .MoveAt(2, 2).Game.Print()
                .MoveAt(2, 0).Game.Print()
                .MoveAt(1, 0).Game.Print()
                .MoveAt(0, 2).Game.Print()
                .MoveAt(0, 1).Game.Print()
                .MoveAt(1, 1).Game.Print()
            ;

        //TODO: Need to implement winning
        //result.GameState.ShouldBe(PlayerWon(Player.O));
        // O should have won
    }
}