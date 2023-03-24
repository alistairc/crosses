namespace Crosses.Core;

public abstract record SquareState
{
    public static readonly SquareState Blank = new BlankState();

    public static SquareState Filled(Player player) => new FilledState(player);

    //closed set
    SquareState()
    {
    }

    public abstract T Match<T>(
        Func<FilledState, T> onFilled,
        Func<BlankState, T> onBlank
    ); 

    public static SquareState FromPlayer(Player player)
    {
        return player.Match(Filled(Player.O), Filled(Player.X));
    }

    public record BlankState : SquareState
    {
        public override T Match<T>(Func<FilledState, T> onFilled, Func<BlankState, T> onBlank)
        {
            return onBlank(this);
        }

        public override string ToString() => " ";
    }
    
    public record FilledState(Player player) : SquareState
    {
        public override T Match<T>(Func<FilledState, T> onFilled, Func<BlankState, T> onBlank)
        {
            return onFilled(this);
        }

        public override string ToString() => player.ToString();
    }
}