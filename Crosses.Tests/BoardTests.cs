namespace Crosses.Tests;

class BoardTests
{
    [Test]
    public void NewGame()
    {
        var board = Game.Start();
        board.StateAt(0, 0).ShouldBe(SquareState.Blank);
        board.StateAt(0, 1).ShouldBe(SquareState.Blank);
        board.StateAt(0, 2).ShouldBe(SquareState.Blank);
        board.StateAt(1, 0).ShouldBe(SquareState.Blank);
        board.StateAt(1, 1).ShouldBe(SquareState.Blank);
        board.StateAt(1, 2).ShouldBe(SquareState.Blank);
        board.StateAt(2, 0).ShouldBe(SquareState.Blank);
        board.StateAt(2, 1).ShouldBe(SquareState.Blank);
        board.StateAt(2, 2).ShouldBe(SquareState.Blank);
    }

    [Test]
    public void RemembersMoves()
    {
        var board = Game.Start()
            .MoveAt(0, 0, Player.O)
            .MoveAt(1, 1, Player.X);
        
        board.StateAt(0,0).ShouldBe(SquareState.Nought);
        board.StateAt(1,1).ShouldBe(SquareState.Cross);
        board.StateAt(2,2).ShouldBe(SquareState.Blank);
    }
}