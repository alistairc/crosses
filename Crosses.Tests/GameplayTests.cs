using Crosses.Core;

namespace Crosses.Tests;

public class GameplayTests
{
    [Test]
    public void PlayingACompleteGame()
    {
        var result = Game.Start().Print()
                .MoveAt(0, 0).Print()
                .MoveAt(2, 2).Print()
                .MoveAt(2, 0).Print()
                .MoveAt(1, 0).Print()
                .MoveAt(0, 2).Print()
                .MoveAt(0, 1).Print()
                .MoveAt(1, 1).Print()
            ;

        //TODO: Need to implement winning
        //result.GameState.ShouldBe(PlayerWon(Player.O));
        // O should have won
    }
}