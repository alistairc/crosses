using Crosses.Core;

namespace Crosses.Tests;

class BoardTests
{
    [Test]
    public void InitialBoard_ShouldBeBlank()
    {
        var board = new Board();
        board.GetSquareState(0, 0).ShouldBe(SquareState.Blank);
        board.GetSquareState(0, 1).ShouldBe(SquareState.Blank);
        board.GetSquareState(0, 2).ShouldBe(SquareState.Blank);
        board.GetSquareState(1, 0).ShouldBe(SquareState.Blank);
        board.GetSquareState(1, 1).ShouldBe(SquareState.Blank);
        board.GetSquareState(1, 2).ShouldBe(SquareState.Blank);
        board.GetSquareState(2, 0).ShouldBe(SquareState.Blank);
        board.GetSquareState(2, 1).ShouldBe(SquareState.Blank);
        board.GetSquareState(2, 2).ShouldBe(SquareState.Blank);
    }

    [Test]
    public void ShouldRememberMoves()
    {
        var board = new Board()
            .SetSquareState(0, 0, Player.O)
            .SetSquareState(1, 1, Player.X);

        board.GetSquareState(0, 0).ShouldBe(SquareState.Nought);
        board.GetSquareState(1, 1).ShouldBe(SquareState.Cross);
        board.GetSquareState(2, 2).ShouldBe(SquareState.Blank);
    }

    [Test]
    public void ShouldSupportValueEquality()
    {
        new Board().ShouldBe(new Board());
        new Board().ShouldBe(Board.Blank);
        new Board().SetSquareState(1, 1, Player.O).ShouldNotBe(Board.Blank);
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        (new Board() == null).ShouldBeFalse();
    }

    [Test]
    public void ShouldStringifyNicely()
    {
        Board.Blank
            .SetSquareState(0, 0, Player.O)
            .SetSquareState(0, 1, Player.X)
            .SetSquareState(1, 1, Player.O)
            .SetSquareState(2, 2, Player.X)
            .ToString()
            .ShouldBe("O  \nXO \n  X");
    }
}