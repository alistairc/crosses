using Crosses.Core;

namespace Crosses.Tests;

class BoardTests
{
    [Test]
    public void InitialBoard_ShouldBeBlank()
    {
        var board = new Board();
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
    public void ShouldRememberMoves()
    {
        var board = new Board()
            .SetState(0, 0, Player.O)
            .SetState(1, 1, Player.X);

        board.StateAt(0, 0).ShouldBe(SquareState.Nought);
        board.StateAt(1, 1).ShouldBe(SquareState.Cross);
        board.StateAt(2, 2).ShouldBe(SquareState.Blank);
    }

    [Test]
    public void ShouldSupportValueEquality()
    {
        (new Board()).ShouldBe(new Board());
        (new Board()).ShouldBe(Board.Blank);
        (new Board().SetState(1,1,Player.O)).ShouldNotBe(Board.Blank);
        (new Board() == null).ShouldBeFalse();
    }
}