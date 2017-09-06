using System.Collections.Generic;

namespace TicTacToe
{
    internal class GameLogic
    {
        private static List<(int x, int y)> moveList = new List<(int, int)>();

        internal static void RegisterTurn((int x, int y) coordinates)
        {
            moveList.Add((coordinates.x, coordinates.y));
        }

        internal static List<(int x, int y)> MoveList => moveList;

        public static void ClearList()
        {
            moveList.Clear();
        }
    }
}
