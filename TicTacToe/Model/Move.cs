namespace TicTacToe.Model
{
    public class Move
    {
        public Move(int x, int y, CellState player)
        {
            X = x;
            Y = y;
            Player = player;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public CellState Player { get; private set; }
    }
}
