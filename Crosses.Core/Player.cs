namespace Crosses.Core;

public class Player
{
    public static readonly Player O = new("O");
    public static readonly Player X = new("X");

    readonly string _name;

    //Closed set
    Player(string name)
    {
        _name = name;
    }

    public static Player Other(Player currentPlayer)
    {
        return currentPlayer.Match(X, O);
    }

    public override string ToString()
    {
        return _name;
    }

    public T Match<T>(T noughtsValue, T crossValue)
    {
        return this == O ? noughtsValue : crossValue;
    }
}