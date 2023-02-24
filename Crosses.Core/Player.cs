namespace Crosses.Core;

public class Player
{
    public static readonly Player O = new("O");
    public static readonly Player X = new("X");

    public static Player Other(Player currentPlayer)
    {
        return currentPlayer.Match(noughtsValue: X, crossValue: O);
    }

    readonly string _name;

    //Closed set
    Player(string name)
    {
        _name = name;
    }

    public override string ToString() => _name;

    public T Match<T>(T noughtsValue, T crossValue)
    {
        return this == O ? noughtsValue : crossValue;
    }
}