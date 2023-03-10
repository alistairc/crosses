namespace Crosses.Core;

//TODO: collapse Game and GameState 
public abstract record GameState
{
    public static readonly GameState Complete = new CompleteState();

    // We'll introduce these next
    // public static readonly GameState Draw = new GameState();
    // public static readonly GameState Won = new GameState();

    GameState()
    {
    }

    public static GameState InProgress(Player nextPlayer)
    {
        return new InProgressState(nextPlayer);
    }

    public abstract T Match<T>(Func<InProgressState, T> onInProgress, Func<CompleteState, T> onComplete);

    public record InProgressState(Player NextTurn) : GameState
    {
        public override T Match<T>(Func<InProgressState, T> onInProgress, Func<CompleteState, T> onComplete)
        {
            return onInProgress(this);
        }
    }

    public record CompleteState : GameState
    {
        public override T Match<T>(Func<InProgressState, T> onInProgress, Func<CompleteState, T> onComplete)
        {
            return onComplete(this);
        }
    }
}