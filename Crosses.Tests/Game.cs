namespace Crosses.Tests;

//TODO: Drive out some of this, tests no longer use it 
record Game
{
    public Board Board { get; }
    public Player NextTurn { get; }

    Game(Board board, Player nextTurn)
    {
        Board = board;
        NextTurn = nextTurn;
    }

    public static Game Start()
    {
        return new Game(new Board(), Player.O);
    }

    public Game MoveAt(int x, int i1)
    {
        return null;
    }
}