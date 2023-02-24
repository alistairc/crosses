namespace Crosses.Core;

public class SquareState
{
    public static readonly SquareState Blank = new(" ");
    public static readonly SquareState Nought = new("O");
    public static readonly SquareState Cross = new("X");

    readonly string _name;

    //closed set
    SquareState(string name)
    {
        _name = name;
    }

    public static SquareState FromPlayer(Player player)
    {
        return player.Match(Nought, Cross);
    }

    public override string ToString()
    {
        return _name;
    }
}