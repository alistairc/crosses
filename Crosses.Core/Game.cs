namespace Crosses.Core;

//TODO: Drive out some of this, tests no longer use it 
public record Game
{
    Game(Board board, Player nextTurn)
    {
        Board = board;
        NextTurn = nextTurn;
    }

    public Board Board { get; }
    public Player NextTurn { get; }

    public static Game Start()
    {
        return new Game(new Board(), Player.O);
    }

    public Game MoveAt(int x, int i1)
    {
        return null;
    }
}