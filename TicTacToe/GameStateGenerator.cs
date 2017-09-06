using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe
{
    class GameStateGenerator
    {
        internal static Cell[] GenerateBoard(List<Move> moveList)
        {
            var initGameState = GameState.Init();
            var cells = initGameState.Board;

            foreach (var move in moveList)
            {
                cells.Single(c => c.X == move.X && c.Y == move.Y).CellState = move.Player;
            }
            return cells;
        }

        private static CellState GetCellStateToSet(ValueTuple<int, int> turn, List<(int x, int y)> moveList)
        {
            var cellStateToSet = CellState.none;

            var index = moveList.IndexOf(turn);
            var mod = index % 2;

            if (mod == 0)
            {
                cellStateToSet = CellState.X;
            }
            else if (mod == 1)
            {
                cellStateToSet = CellState.O;
            }
            return cellStateToSet;
        }


    }
}
