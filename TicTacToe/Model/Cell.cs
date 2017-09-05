namespace TicTacToe
{
    public class Cell
    {
        public Cell(int x, int y, CellState cellState)
        {
            X = x;
            Y = y;
            CellState = cellState;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public CellState CellState { get; private set; }
    }
}