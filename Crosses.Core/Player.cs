namespace Crosses.Core;

public class Player
{
    readonly string _name;

    //Closed set
    Player(string name)
    {
        _name = name;
    }

    public override string ToString() => _name;

    public static readonly Player O = new("O");
    public static readonly Player X = new("X");

    public static Player Other(Player currentPlayer)
    {
        if (currentPlayer == Player.O)
            return Player.X;
        if (currentPlayer == Player.X)
            return Player.O;
        throw new ArgumentOutOfRangeException(nameof(currentPlayer), currentPlayer, null);
    }
}