namespace Crosses.Tests;

public class GameplayTests
{
    [Test]
    public void PlayingACompleteGame()
    {
        Game.Start().Print()
            .MoveAt(0, 0).ShouldSucceed().Print()
            .MoveAt(2, 2).ShouldSucceed().Print()
            .MoveAt(2, 0).ShouldSucceed().Print()
            .MoveAt(1, 0).ShouldSucceed().Print()
            .MoveAt(0, 2).ShouldSucceed().Print()
            .MoveAt(0, 1).ShouldSucceed().Print()
            .MoveAt(1, 1).ShouldSucceed().Print();

        //TODO: Need to implement winning
        //result.GameState.ShouldBe(PlayerWon(Player.O));
        // O should have won
    }
}