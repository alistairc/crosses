namespace Crosses.Tests;

class GameTests
{
    [Test]
    public void StartingAGame_ShouldHaveABlankBoardAndAnInitialPlayer()
    {
        var game = Game.Start();
        game.Board.ShouldBe(Board.Blank);
        game.State.ShouldBe(GameState.InProgress(Player.O));
    }

    [Test]
    public void MakingAMove_ShouldUpdateTheBoard()
    {
        var game = Game.Start().MoveAt(1, 2).ShouldSucceed();
        game.Board.GetSquareState(1, 2).ShouldBe(SquareState.Nought);
    }

    [Test]
    public void MakingAMove_ShouldAlternatePlayers()
    {
        var gameState1 = Game.Start().MoveAt(1, 1).ShouldSucceed();
        var gameState2 = gameState1.MoveAt(2, 2).ShouldSucceed();

        gameState1.State.ShouldBe(GameState.InProgress(Player.X));
        gameState2.State.ShouldBe(GameState.InProgress(Player.O));
    }

    [Test]
    public void ShouldKnowWhenGameIsComplete()
    {
        var game = Game.Start()
            .MoveAt(0, 0).ShouldSucceed()
            .MoveAt(0, 1).ShouldSucceed()
            .MoveAt(0, 2).ShouldSucceed()
            .MoveAt(1, 0).ShouldSucceed()
            .MoveAt(1, 1).ShouldSucceed()
            .MoveAt(1, 2).ShouldSucceed()
            .MoveAt(2, 0).ShouldSucceed()
            .MoveAt(2, 1).ShouldSucceed()
            .MoveAt(2, 2).ShouldSucceed();

        game.State.ShouldBe(GameState.Complete);
    }

    [Test]
    public void ShouldFailOnMovesNotInBlanks()
    {
        Game.Start()
            .MoveAt(1, 1).ShouldSucceed()
            .MoveAt(1, 1).ShouldFail();
    }
}