﻿using Crosses.Core;

namespace Crosses.Tests;

class GameTests
{
    [Test]
    public void StartingAGame_ShouldHaveABlankBoardAndAnInitialPlayer()
    {
        var game = Game.Start();
        game.Board.ShouldBe(Board.Blank);
        game.NextTurn.ShouldBe(Player.O);
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

        gameState1.NextTurn.ShouldBe(Player.X);
        gameState2.NextTurn.ShouldBe(Player.O);
    }

    [Test]
    public void ShouldFailOnMovesNotInBlanks()
    {
        Game.Start()
            .MoveAt(1, 1).ShouldSucceed()
            .MoveAt(1, 1).ShouldFail();
    }
}