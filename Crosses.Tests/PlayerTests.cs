namespace Crosses.Tests;

class PlayerTests
{
    [Test]
    public void ShouldStringifyNicely()
    {
        Player.O.ToString().ShouldBe("O");
        Player.X.ToString().ShouldBe("X");
    }
}