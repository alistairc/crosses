namespace Crosses.Core;

public class SquareState
{
    public static readonly SquareState Blank = new(" ");
    public static readonly SquareState Nought = new("O");
    public static readonly SquareState Cross = new("X");

    public static SquareState FromPlayer(Player player)
        => player.Match(noughtsValue: Nought, crossValue: Cross);

    readonly string _name;

    //closed set
    SquareState(string name)
    {
        _name = name;
    }

    public override string ToString() => _name;
}