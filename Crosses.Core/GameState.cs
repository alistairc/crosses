namespace Crosses.Core;

//TODO: collapse Game and GameState 
public abstract record GameState
{
    public static readonly GameState Complete = new CompleteState();

    GameState()
    {
    }

    public static GameState InProgress(Player nextPlayer)
    {
        return new InProgressState(nextPlayer);
    }

    public static GameState Won(Player winner)
    {
        return new WonState(winner);
    }

    public abstract T Match<T>(
        Func<InProgressState, T> onInProgress,
        Func<CompleteState, T> onComplete,
        Func<WonState, T> onWinner
    );

    public record InProgressState(Player NextTurn) : GameState
    {
        public override T Match<T>(Func<InProgressState, T> onInProgress, Func<CompleteState, T> onComplete,
            Func<WonState, T> onWinner)
        {
            return onInProgress(this);
        }
    }

    public record CompleteState : GameState
    {
        public override T Match<T>(Func<InProgressState, T> onInProgress, Func<CompleteState, T> onComplete,
            Func<WonState, T> onWinner)
        {
            return onComplete(this);
        }
    }

    public record WonState(Player Winner) : GameState
    {
        public override T Match<T>(Func<InProgressState, T> onInProgress, Func<CompleteState, T> onComplete,
            Func<WonState, T> onWinner)
        {
            return onWinner(this);
        }
    }
}