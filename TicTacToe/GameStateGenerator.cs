using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameStateGenerator
    {
        internal static Cell[] GenerateBoard(List<(int x, int y)> moveList)
        {
            var initGameState = GameState.Init();
            var cells = initGameState.Board;

            foreach (var turn in moveList)
            {
                var cellStateToSet = GetCellStateToSet(turn, moveList);

                cells.Single(c => c.X == turn.x && c.Y == turn.y).CellState = cellStateToSet;
            }
            return cells;
        }

        internal static Status DetermineNextPlayer(int count)
        {
            var status = Status.TurnX;

            var mod = count % 2;

            if (mod == 0)
            {
                status = Status.TurnX;
            }
            else if (mod == 1)
            {
                status = Status.TurnO;
            }
            return status;
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
