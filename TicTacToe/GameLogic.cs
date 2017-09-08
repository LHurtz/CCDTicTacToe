using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Model;

namespace TicTacToe
{
    internal class GameLogic
    {
        private static List<Move> _moveList = new List<Move>();

        internal static void RegisterMove((int x, int y) coordinates)
        {
            var player = _moveList.Count % 2 == 0 ? CellState.X : CellState.O;
            var move = new Move(coordinates.x, coordinates.y, player);
            _moveList.Add(move);
        }

        internal static List<Move> MoveList => _moveList;

        public static void ClearList()
        {
            _moveList.Clear();
        }

        public static Status DetermineNextStatus(List<Move> moveList)
        {
            return CheckGameOver(moveList) 
                ? Status.Tie 
                : DetermineNextPlayer(moveList);
        }

        internal static bool CheckGameOver(List<Move> moveList)
        {
            var isGameOver = moveList.Count == 9;

            return isGameOver;
        }

        internal static Status DetermineNextPlayer(List<Move> moveList)
        {
            var moveCount = moveList.Count; 
            var status = moveCount % 2 == 0 ? Status.TurnX : Status.TurnO;

            return status;
        }

        public static List<Move> TransformCoordinatesToMoves(List<(int x, int y)> coordinates)
        {
            throw new NotImplementedException();
        }
    }
}