namespace TicTacToe
{
    public class GameState
    {
        public GameState(Cell[] board, Status status)
        {
            Board = board;
            Status = status;
        }

        public Cell[] Board { get; private set; }
        public Status Status { get; private set; }

        public static GameState Init()
        {
            return new GameState(
                new Cell[9]
                {
                    new Cell(0, 0, CellState.none), new Cell(1, 0, CellState.none), new Cell(2, 0, CellState.none) ,
                   new Cell(0, 1, CellState.none), new Cell(1, 1, CellState.none), new Cell(2, 1, CellState.none) ,
                    new Cell(0, 2, CellState.none), new Cell(1, 2, CellState.none), new Cell(2, 2, CellState.none)
                },
                TicTacToe.Status.TurnX);
        }
    }
}
