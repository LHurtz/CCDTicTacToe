namespace TicTacToe.Model
{
    internal class ReplayState
    {
        public int TotalMoveCount { get; private set; }
        public int CurrentMoveIndex { get; private set; }
        public bool IsPlaying { get; set; }
    }
}